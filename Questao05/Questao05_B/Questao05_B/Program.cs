using System;

namespace Questao05_B
{
    class Program
    {
        static void Main(string[] args)
        {
            var core = new Core("dados.csv");

            core.CalcularVariacao();
        }
    }
}
