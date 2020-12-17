using System;

namespace Questao03
{
    class Core
    {
        private static readonly string MENSAGEM_IDEAL = "Portanto, idealmente, o máximo de sua renda comprometida com {0} mas deveria ser de {1}";
        private static readonly string MENSAGEM_RECOMENDADA = "Seus gastos estão dentro da margem recomendada.";
        private static readonly string MENSAGEM_PADRAO = "Seus gastos totais com {0} comprometem {1} % de sua renda total.O máximo recomendado é de {2} %.";

        public static decimal percentualMoradia;
        public static decimal percentualEducacao;
        public static decimal percentualTransporte;

        public static decimal valorRendaMensal;
        public static decimal valorMoradia;
        public static decimal valorEducacao;
        public static decimal valorTransporte;

        public static void ValidarValores()
        {
            percentualMoradia = CalcularPercetual(valorMoradia, valorRendaMensal);
            percentualEducacao = CalcularPercetual(valorEducacao, valorRendaMensal);
            percentualTransporte = CalcularPercetual(valorTransporte, valorRendaMensal);
                        
            Console.WriteLine("Renda mensal total: {0}.", FormatarValor(valorRendaMensal));
            Console.WriteLine("Gastos totais com moradia: {0}.", FormatarValor(valorMoradia));
            Console.WriteLine("Gastos totais com educação: {0}.", FormatarValor(valorEducacao));
            Console.WriteLine("Gastos totais com transporte: {0}.", FormatarValor(valorTransporte));
            Console.WriteLine("");

            Console.WriteLine("Diagnóstico:");

            if((valorMoradia + valorEducacao + valorTransporte) > valorRendaMensal)
            {
                Console.WriteLine("Seus gastão estão maior que sua renda.");

                Console.WriteLine("Total de gastos: {0}.", FormatarValor(valorMoradia + valorEducacao + valorTransporte));

                return;
            }
                
            
            Console.Write(MENSAGEM_PADRAO, "Moradia", percentualMoradia, 30);
            Console.Write(percentualMoradia > 30 ? String.Format(MENSAGEM_IDEAL, FormatarValor(valorMoradia), FormatarValor(CalcularValor(valorRendaMensal, 30))) : MENSAGEM_RECOMENDADA);
            Console.WriteLine("");

            Console.Write(MENSAGEM_PADRAO, "Educação", percentualEducacao, 20);
            Console.Write(percentualMoradia > 20 ? String.Format(MENSAGEM_IDEAL, FormatarValor(valorEducacao), FormatarValor(CalcularValor(valorRendaMensal, 20))) : MENSAGEM_RECOMENDADA);
            Console.WriteLine("");

            Console.Write(MENSAGEM_PADRAO, "Transporte",percentualTransporte, 15);
            Console.Write(percentualMoradia > 15 ? String.Format(MENSAGEM_IDEAL, FormatarValor(valorTransporte), FormatarValor(CalcularValor(valorRendaMensal, 15))) : MENSAGEM_RECOMENDADA);
            Console.WriteLine("");
        }       

        public static string lerNumeros()
        {
            ConsoleKeyInfo cki;
            string entrada = "";
            bool continuarLoop = true;
            while (continuarLoop)
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.Backspace:
                            if (entrada.Length == 0) continue;
                            entrada = entrada.Remove(entrada.Length - 1);
                            Console.Write("\b \b"); //Remove o último caractere digitado
                            break;
                        case ConsoleKey.Enter:
                            continuarLoop = false;
                            break;
                        case ConsoleKey key when ((ConsoleKey.D0 <= key) && (key <= ConsoleKey.D9) ||
                                                  (ConsoleKey.NumPad0 <= key) && (key <= ConsoleKey.NumPad9)):
                            entrada += cki.KeyChar;
                            Console.Write(cki.KeyChar);
                            break;
                    }
                }
            return entrada;
        }

        private static decimal CalcularPercetual(decimal valor, decimal valorMensal)
        {
            return Decimal.Round((valor * 100) / valorMensal, 2);
        }

        private static decimal CalcularValor(decimal valorMensal, decimal percentual) 
        {
            return Decimal.Round((valorMensal * percentual) / 100);
        }

        private static string FormatarValor(decimal valor)
        {
            return String.Format("{0:C}", valor);

        }
    }
}
