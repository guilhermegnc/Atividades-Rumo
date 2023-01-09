namespace Atividade1_ConsumoCarro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Consumo veiculo = new Consumo();
            veiculo.LerCapacidadeTanque();
            veiculo.LerQuilometrosRodados();
            veiculo.ExibirResultado();
        }
    }
}