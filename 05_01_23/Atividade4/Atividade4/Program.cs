namespace Atividade4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programa para calcular o lucro da venda de um produto\n\n");

            CalculadoraDeLucros produtos = new CalculadoraDeLucros();
            produtos.EntradaDeDados();
            produtos.CalculaLucro();
            produtos.ExibeLucro();
        }
    }
}