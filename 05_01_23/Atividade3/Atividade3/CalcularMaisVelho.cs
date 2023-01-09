using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade3
{
    public class CalcularMaisVelho
    {
        private String?[] Nomes = new String[10];    // vetor com os nomes
        private int[] Idades = new int[10];         // vetor com as idades
        private int MaiorIdade = 0;
        private List<int> posicoes = new List<int>();   // lista com as posições onde está a maior idade, para acesso rápido
        private int idade;

        public void EntradaDeDados()
        {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Entre com o {0:N0}º nome", i+1);
                Nomes[i] = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Nomes[i]))    // verifica se a entrada é null, vazia ou whitespace
                {
                    Console.WriteLine("Valor inválido");
                    i--;    // se a entrada é invalida retorna uma posição do interador para entrar com valor correto
                    continue;
                }

                Console.WriteLine("Entre com a {0:N0}ª idade", i+1);
                if (!int.TryParse(Console.ReadLine(), out idade))   // verifica se´é um inteiro
                {
                    Console.WriteLine("Valor inválido");
                    i--;
                    continue;
                }

                if (validaValor(idade))
                {
                    Idades[i] = idade;
                    if (idade > MaiorIdade) // adiciona o valor se a idade entrada pelo usuario é a maior idade
                    {
                        MaiorIdade = idade;
                        posicoes.Clear();   // limpa a lista com as posições para acesso rápido às maiores idades
                        posicoes.Add(i);    // adiciona a posição atual
                    }
                    else if (idade == MaiorIdade) posicoes.Add(i);
                }
            }
        }

        private bool validaValor(int valor)     // verifica se a idade é negativa
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
