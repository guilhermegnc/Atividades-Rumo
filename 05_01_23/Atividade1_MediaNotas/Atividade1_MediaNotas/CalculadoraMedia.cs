using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1_MediaNotas
{
    public class CalculadoraMedia
    {
        private List<float> notas = new List<float>();
        private float nota;
        private int contador = 0;

        public void EntradaDeNotas()
        {
            Console.WriteLine("Entrada de notas dos alunos. Entre com -1 para parar\n");
            bool parada = false;
            while(!parada)
            {
                Console.WriteLine("Nota do {0:N0}º Aluno", contador + 1);
                if(!float.TryParse(Console.ReadLine(), out nota))
                {
                    Console.WriteLine("Valor inválido");
                }
                if (nota >= 0)
                {
                    notas.Add(nota);
                    contador++;
                }
                else if (nota == -1)
                {
                    parada = true;
                }
                else
                {
                    Console.WriteLine("Valor inválido");
                }
            }
        }

        public void CalcularMedia()
        {
            float media = notas.Sum() / contador;
            Console.WriteLine("\nA média de notas da turma é {0:N2}", media);
        }
    }
}
