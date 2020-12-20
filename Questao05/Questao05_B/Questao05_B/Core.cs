using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Questao05_B
{
    public class Core
    {
        private ReadCVS cvs;
        private DataTable dados;

        public Core(string nomeArquivo)
        {
            this.cvs = new ReadCVS(GetCaminhoAplicacao() + nomeArquivo);
            this.dados = cvs.read();
        }


        public void CalcularVariacao() 
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Variação de % entre 2013 e 2020.");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(String.Format("{0,-15} | {1,12} |", "País", "Variação"));
            Console.WriteLine("-----------------------------------");

            foreach (DataRow row in this.dados.Rows)
            {
                decimal valor2013 = Convert.ToDecimal(row["2013"].ToString().Replace(".",","));
                decimal valor2020 = Convert.ToDecimal(row["2020"].ToString().Replace(".", ","));

                decimal variacao = Decimal.Round(((valor2020 - valor2013) / valor2013) * 100, 2);

                Console.WriteLine(String.Format("{0,-15} | {1,10} % |", row["País"] , variacao));                               
            }
        }


        private string GetCaminhoAplicacao()
        {
            return Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\";
        }
    }
}
