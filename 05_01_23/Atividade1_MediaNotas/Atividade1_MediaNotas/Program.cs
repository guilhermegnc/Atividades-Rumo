namespace Atividade1_MediaNotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculadoraMedia turma = new CalculadoraMedia();
            turma.EntradaDeNotas();
            turma.CalcularMedia();
        }
    }
}