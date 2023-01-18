using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa2
{
    public class ClassificaPorIdade
    {

        public static void Classifica()
        {
            Console.WriteLine("Entre com sua idade:");

            if (!int.TryParse(Console.ReadLine(), out var idade) || idade < 0 || idade > 120)
            {
                Console.WriteLine("Idade entrada é inválido");
                return;
            }

            Console.Clear();

            if (idade >= 5 && idade <= 7) Console.WriteLine("Sua classificação é Infantil A");
            else if (idade >= 8 && idade <= 10) Console.WriteLine("Sua classificação é Infantil B");
            else if (idade >= 11 && idade <= 13) Console.WriteLine("Sua classificação é Juvenil A");
            else if (idade >= 14 && idade <= 17) Console.WriteLine("Sua classificação é Juvenil B");
            else if (idade >= 18 && idade <= 25) Console.WriteLine("Sua classificação é Senior");
            else Console.WriteLine("Infelizmente você não está classificado em nenhuma faixa etária");

        }
    }
}
