using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Questao05_B
{
    class ReadCVS
    {
        private string filePath;

        public ReadCVS(string filePath)
        {
            this.filePath = filePath;
        }

        public DataTable read()
        {
            var dt = new DataTable();

            foreach (var headerLine in File.ReadLines(this.filePath).Take(1))
            {
                foreach (var headerItem in headerLine.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dt.Columns.Add(headerItem.Trim(), typeof(string));
                }
            }
                        
            foreach (var line in File.ReadLines(filePath).Skip(1))
            {
                dt.Rows.Add(line.Split(','));
            }

            return dt;
        }
    }
}
