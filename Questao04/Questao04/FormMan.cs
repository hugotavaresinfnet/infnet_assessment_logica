using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormMan : Form
    {       
        public FormMan()
        {
            InitializeComponent();
        }

        private void txtValorInicial_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            Funcoes.Moeda(ref txt);
        }

        private void txtAporteMensal_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            Funcoes.Moeda(ref txt);
        }

        private void txtRendimentos_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = ((TextBox)sender);
            Funcoes.Moeda(ref txt);
        }

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimparCampos();
            ExibirValores();

            var th = new Thread(Calcular);
            th.Start();
        }

        private Boolean CamposPreenchidos()
        {
            if (txtValorInicial.Text.Trim() == Funcoes.VALOR_ZERO)
                return false;

            if (txtAporteMensal.Text.Trim() == Funcoes.VALOR_ZERO)
                return false;

            if (txtRendimentos.Text.Trim() == Funcoes.VALOR_ZERO)
                return false;

            if (txtPeriodo.Text.Trim() == Funcoes.VALOR_ZERO)
                return false;

            return true;
        }

        private void FormMan_Load(object sender, EventArgs e)
        {
            txtValorInicial.Text = Funcoes.VALOR_ZERO;
            txtAporteMensal.Text = Funcoes.VALOR_ZERO;
            txtRendimentos.Text = Funcoes.VALOR_ZERO;
            txtPeriodo.Text = "0";
        }


        private void ExibirValores()
        {
            chart1.Titles[0].Text = String.Format("Rendimentos no período de {0} meses" , txtPeriodo.Text); 

            lblValorInicial.Text = String.Format(Funcoes.LBL_VALOR_INICIAL, txtValorInicial.Text);
            lblAporte.Text = String.Format(Funcoes.LBL_APORTE_MENSAL, txtAporteMensal.Text);
            lblRendimento.Text = String.Format(Funcoes.LBL_RENDIMENTOS, txtRendimentos.Text);
            lblPeriodo.Text = String.Format(Funcoes.LBL_PERIODO, txtPeriodo.Text);
        }

        private void Calcular()
        {
            string texto = "";
            decimal valorRendimento = 0;
            decimal valorInicial = Convert.ToDecimal(txtValorInicial.Text);
            decimal aporte = Convert.ToDecimal(txtAporteMensal.Text);
            decimal redimento = Convert.ToDecimal(txtRendimentos.Text);
            decimal periodo = Convert.ToInt32(txtPeriodo.Text);

            for (int i = 0; i < periodo; i++)
            {
                valorRendimento = valorInicial + aporte + Funcoes.CalcularRendimentos(valorInicial, redimento);


                texto += String.Format(Funcoes.MENSAGEM, Convert.ToString(i + 1), Funcoes.FormatarValor(valorRendimento))+ "\r\n" ;


                Funcoes.AtualizarGraficoControle(chart1, Convert.ToString(i + 1), valorRendimento);


                Funcoes.AtualizarValoresControle(txtResultado, "Text", texto);

                valorInicial = valorRendimento;
            }

            Funcoes.AtualizarValoresControle(lblMontante, "Text", String.Format(Funcoes.LBL_MONTANTE, Funcoes.FormatarValor(valorRendimento)));
            
        }

        private void LimparCampos()
        {
            txtResultado.Clear();
            lblMontante.Text = String.Format(Funcoes.LBL_MONTANTE, Funcoes.VALOR_ZERO);
            chart1.Series.Clear();

            chart1.Series.Add("Rendimentos");
        }

    }
}
