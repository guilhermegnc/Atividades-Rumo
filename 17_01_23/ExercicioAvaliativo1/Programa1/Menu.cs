using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa1
{
    public class Menu
    {

        public static void ShowMenu()
        {
            Console.WriteLine("Converter para qual moeda: 1-Dolar  2-Euro  3-Peso Argentino  4-Baht Tailândes");

            int opcao;
            if(!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção Inválida");
            }

            Console.Clear();

            switch (opcao)
            {

                case 1:
                    ConversãoMoeda.GetValorReal();
                    ConversãoMoeda.ConverteEmDolar();
                    break;

                case 2:
                    ConversãoMoeda.GetValorReal();
                    ConversãoMoeda.ConverteEmEuro();
                    break;

                case 3:
                    ConversãoMoeda.GetValorReal();
                    ConversãoMoeda.ConverteEmPesoArgentino();
                    break;

                case 4:
                    ConversãoMoeda.GetValorReal();
                    ConversãoMoeda.ConverteEmBahtTailandes();
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        }
    }
}
