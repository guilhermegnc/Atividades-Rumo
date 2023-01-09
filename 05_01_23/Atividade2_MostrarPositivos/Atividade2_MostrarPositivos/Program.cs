namespace Atividade2_MostrarPositivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vetor = new int[15];

            for(int i=0; i<15; i++)
            {
                Console.WriteLine("Entre com o {0:N0}º valor", i + 1);
                if (!int.TryParse(Console.ReadLine(), out vetor[i]))
                {
                    Console.WriteLine("Valor Inválido");
                    i--;
                }
            }
            Console.WriteLine("\nAbaixo serão listados todos os números positivos");
            foreach (int valor in vetor)
            {
                if (valor > 0) Console.WriteLine("Número: {0:N0}", valor);
            }
        }
    }
}