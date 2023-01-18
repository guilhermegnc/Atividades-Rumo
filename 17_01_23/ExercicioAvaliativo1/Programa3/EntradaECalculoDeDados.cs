using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa3
{
    public class EntradaECalculoDeDados
    {
        private static decimal nivel1 = 12.00M;
        private static decimal nivel2 = 18.00M;
        private static decimal nivel3 = 25.00M;
        private static int horasDeTrabalho;

        public static void ValorPago()
        {
            Console.WriteLine("Entre com o seu nível (1,2 ou 3):");
            if (!int.TryParse(Console.ReadLine(), out var escolha))
            {
                Console.WriteLine("Nível inválido");
            }

            Console.Clear();

            switch(escolha)
            {
                case 1:
                    var validacao = GetHorasDeTrabalho();
                    if (validacao)
                    {
                        Console.WriteLine("O valor pago pelo dia de trabalho será: {0:N2} Reais", horasDeTrabalho * nivel1);
                    }
                    break;

                case 2:
                    validacao = GetHorasDeTrabalho();
                    if (validacao)
                    {
                        Console.WriteLine("O valor pago pelo dia de trabalho será: {0:N2} Reais", horasDeTrabalho * nivel2);
                    }
                    break;

                case 3:
                    validacao = GetHorasDeTrabalho();
                    if (validacao)
                    {
                        Console.WriteLine("O valor pago pelo dia de trabalho será: {0:N2} Reais", horasDeTrabalho * nivel3);
                    }
                    break;

                default:
                    Console.WriteLine("Nível inválido");
                    break;
            }
        }

        private static bool GetHorasDeTrabalho()
        {
            Console.WriteLine("Entre com suas horas de trabalha:");

            if(!int.TryParse(Console.ReadLine(), out horasDeTrabalho) || horasDeTrabalho < 0 || horasDeTrabalho > 24)
            {
                Console.WriteLine("Entrada Inválida");
                return false;
            }

            Console.Clear();
            return true;

        }
    }
}
