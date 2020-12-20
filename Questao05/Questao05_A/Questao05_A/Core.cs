using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Questao05_A
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

        public void GetPIB(string pais, string ano)
        {
            if (!dados.Columns.Contains(ano))
            {
                Console.WriteLine("Ano não disponível.");
                return;
            }

            foreach (DataRow row in this.dados.Rows)
            {
                if (row["País"].ToString().ToUpper() == pais.ToUpper())
                {
                    Console.WriteLine("PIB Brasil em 2020: US${0} trilhões.", row[ano]);

                    return;
                }

            }

            Console.WriteLine("País não disponível.");
        }

        private string GetCaminhoAplicacao()
        {
            return Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString()) + "\\";
        }
    }
}
