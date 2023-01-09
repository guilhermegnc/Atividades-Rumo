namespace Atividade2_QuilometragemMaxima
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Veiculo veiculo = new Veiculo();

            veiculo.LerLitrosAbastecidos();
            veiculo.LerConsumo();
            veiculo.ExibirResultado();
        }
    }
}