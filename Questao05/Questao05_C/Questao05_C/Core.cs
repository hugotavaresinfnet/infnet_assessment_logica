using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Questao05_C
{
    public class Core
    {
        private ReadCVS cvs;
        private DataTable dados;
        private Chart chart;

        public Core(string nomeArquivo, Chart chart)
        {
            this.chart = chart;
            this.cvs = new ReadCVS(GetCaminhoAplicacao() + nomeArquivo);
            this.dados = cvs.read();
        }

        public void ExibirEvolucaoGrafico(string pais) 
        {
            chart.Series.Clear();
            chart.Series.Add("PIB");
            foreach (DataRow row in this.dados.Rows)
            {
                if (row["País"].ToString().ToUpper() == pais.ToUpper())
                {
                    for (int i = 2013; i <= 2020; i++)
                    {
                        chart.Series[0].Points.AddXY(i.ToString(), row[i.ToString()]);
                        chart.Series[0].SmartLabelStyle.Enabled = true;
                    }

                    return;
                }
            }
        }
        
        public void CarregarPaises(ref ComboBox cboxPaises) 
        {
            cboxPaises.DataSource = dados;
            cboxPaises.ValueMember = "País";
            cboxPaises.DisplayMember = "País";
        }

        private string GetCaminhoAplicacao()
        {
            return Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\";
        }
    }
}
