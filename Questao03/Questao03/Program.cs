using System;

namespace Questao03
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o valor da renda mensal:");
            Core.valorRendaMensal = int.Parse(Core.lerNumeros());

            Console.Clear();

            Console.WriteLine("Digite o valor gasto moradia:");
            Core.valorMoradia = int.Parse(Core.lerNumeros());

            Console.Clear();

            Console.WriteLine("Digite o valor gasto educação:");
            Core.valorEducacao = int.Parse(Core.lerNumeros());

            Console.Clear();

            Console.WriteLine("Digite o valor gasto transporte:");
            Core.valorTransporte = int.Parse(Core.lerNumeros());

            Console.Clear();

            Core.ValidarValores();
        }        
    }
}
