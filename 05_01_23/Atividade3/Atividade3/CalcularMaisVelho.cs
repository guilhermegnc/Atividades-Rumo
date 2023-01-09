using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3
{
    public class CalcularMaisVelho
    {
        private String[] Nomes = new String[10];
        private int[] Idades = new int[10];
        private int MaiorIdade = 0;
        private List<int> posicoes = new List<int>();
        private int idade;

        public void EntradaDeDados()
        {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Entre com o {0:N0}º nome", i+1);
                Nomes[i] = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Nomes[i]))
                {
                    Console.WriteLine("Valor inválido");
                    i--;
                    continue;
                }

                Console.WriteLine("Entre com a {0:N0}ª idade", i+1);
                if (!int.TryParse(Console.ReadLine(), out idade))
                {
                    Console.WriteLine("Valor inválido");
                    i--;
                    continue;
                }

                if (validaValor(idade))
                {
                    Idades[i] = idade;
                    if (idade > MaiorIdade)
                    {
                        MaiorIdade = idade;
                        posicoes.Clear();
                        posicoes.Add(i);
                    }
                    else if (idade == MaiorIdade) posicoes.Add(i);
                }
            }
        }

        private bool validaValor(int valor)
        {
            if (valor < 0)
            {
                return false;
            }
            else return true;
        }

        public void ExibeMaisVelho()
        {
            Console.WriteLine("\nAbaixo serão listados os mais velhos");
            foreach(int posicao in posicoes)
            {
                Console.Write("Nome: {0}", Nomes[posicao]);
                Console.Write("\t\tIdade: {0:N0} anos\n", Idades[posicao]);
            }
        }
    }
}
