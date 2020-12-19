using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao05
{
    static class Funcoes
    {
        public static DataTable readCSV(string filePath)
        {
            var dt = new DataTable();
            // Creating the columns
            foreach (var headerLine in File.ReadLines(filePath).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim());
                }
            }

            // Adding the rows
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                dt.Rows.Add(line.Split(';'));
            }


            return dt;
        }


        public static string GetCaminhoAplicacao()
        {
            return Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory.ToString())+"\\";
        }
    }
}
