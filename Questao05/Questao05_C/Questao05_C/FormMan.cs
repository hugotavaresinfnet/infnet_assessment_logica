using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Questao05_C
{
    public partial class FormMan : Form
    {
        private Core core;
        
        public FormMan()
        {
            InitializeComponent();

            this.core = new Core("dados.csv", chart1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            core.CarregarPaises(ref comboBox1);


            core.ExibirEvolucaoGrafico(comboBox1.SelectedValue.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            core.ExibirEvolucaoGrafico(comboBox1.SelectedValue.ToString());
        }
    }
}
