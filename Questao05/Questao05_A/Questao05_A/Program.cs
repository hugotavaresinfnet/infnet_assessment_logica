using System;

namespace Questao05_A
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core("dados.csv");


            Console.WriteLine("Informe um país:");
            string pais = Console.ReadLine();
            Console.WriteLine("Informe um ano entre 2013 e 2020:");
            string ano = Console.ReadLine();
            Console.WriteLine("");


            core.GetPIB(pais, ano);
        }
    }
}
