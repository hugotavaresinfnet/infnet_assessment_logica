using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp2
{
    public static class Funcoes
    {

        public delegate void AtualizarValores(Control oControl, string propName, object propValue);
        public delegate void AtualizarGrafico(Control oControl, string serie, decimal value);

        public static readonly string VALOR_ZERO = "0,00";
        public static readonly string LBL_VALOR_INICIAL = "Valor Inicial.......: R$ {0}";
        public static readonly string LBL_APORTE_MENSAL = "Aporte Mensal....: R$ {0}";
        public static readonly string LBL_RENDIMENTOS = "Rendimento.......: % {0}";
        public static readonly string LBL_PERIODO = "Período.............: {0}";
        public static readonly string LBL_MONTANTE = "Montante...........: {0}";
        public static readonly string MENSAGEM = "Após {0} períodos(s), o montante será de {1}.";


        public static void Moeda(ref TextBox txt)
        {
            try
            {
                if (txt.Text != "")
                {
                    char[] textos = txt.Text.ToCharArray();
                    char ultimoCaracter = textos[textos.Length - 1];

                    if (!char.IsNumber(ultimoCaracter))
                    {
                        txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                    }
                }

                string texto = string.Empty;
                double valor = 0;

                texto = txt.Text.Replace(",", "").Replace(".", "");
                if (texto.Equals(""))
                    texto = "";
                texto = texto.PadLeft(3, '0');
                if (texto.Length > 3 & texto.Substring(0, 1) == "0")
                    texto = texto.Substring(1, texto.Length - 1);
                valor = Convert.ToDouble(texto) / 100;

                txt.Text = string.Format("{0:N}", valor);
                txt.SelectionStart = txt.Text.Length;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string RemoverMascaraMoeda(string valor)
        {
            return valor.Replace("R$ ", "").Replace(".", "").Replace(",", ".");
        }

        public static string FormatarValor(decimal valor)
        {
            return String.Format("{0:C}", valor);
        }

        public static decimal CalcularRendimentos(decimal valor, decimal rendimento)
        {
            return Decimal.Round(((valor * rendimento) / 100),2);
        }

        public static void AtualizarValoresControle(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                Funcoes.AtualizarValores d = new Funcoes.AtualizarValores(AtualizarValoresControle);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }

        public static void AtualizarGraficoControle(Control oControl, string serie, decimal value)
        {
            if (oControl.InvokeRequired)
            {
                Funcoes.AtualizarGrafico d = new Funcoes.AtualizarGrafico(AtualizarGraficoControle);
                oControl.Invoke(d, new object[] { oControl, serie, value });
            }
            else
            {
                (oControl as Chart).Series[0].Points.AddXY(serie, Funcoes.FormatarValor(value));
            }
        }
    }
}
