using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    public class ConversãoMoeda
    {
        private static decimal UmEuroEmReal = 5.50M;
        private static decimal UmDolarEmReal = 5.10M;
        private static decimal UmPesoArgentinoEmReal = 0.028M;
        private static decimal UmBahtTailandesEmReal = 0.15M;
        private static decimal Real; 

        public static void GetValorReal()
        {
            Console.WriteLine("Entre com a quantidade de reais a ser convertida:");
            if(!decimal.TryParse(Console.ReadLine(), out Real) || Real < 0)
            {
                Console.WriteLine("Valor entrado é inválido");
            }

            Console.Clear();
        }

        public static void ConverteEmEuro()
        {
            Console.WriteLine("{0} Reais equivale a {1:N3} Euros \n" +
                              $"(Cotação Euro -> 1 Real = {UmEuroEmReal} Euros)", Real, Real / UmEuroEmReal);

        }

        public static void ConverteEmDolar()
        {

            Console.WriteLine("{0} Reais equivale a {1:N3} Dolares \n" +
                              $"(Cotação Dolar -> 1 Real = {UmDolarEmReal} Dolares)", Real, Real / UmDolarEmReal);
        }

        public static void ConverteEmPesoArgentino()
        {
            Console.WriteLine("{0} Reais equivale a {1:N3} Pesos Argentinos \n" +
                              $"(Cotação Dolar -> 1 Real = {UmPesoArgentinoEmReal} Pesos Argentinos)", Real, Real / UmPesoArgentinoEmReal);
        }

        public static void ConverteEmBahtTailandes()
        {
            Console.WriteLine("{0} Reais equivale a {1:N3} Baht Tailândes \n" +
                              $"(Cotação Dolar -> 1 Real = {UmBahtTailandesEmReal} Baht Tailândes)", Real, Real / UmBahtTailandesEmReal);
        }

    }
}
