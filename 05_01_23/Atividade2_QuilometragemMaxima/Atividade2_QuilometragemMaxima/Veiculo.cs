using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2_QuilometragemMaxima
{
    public class Veiculo
    {
        private float ConsumoVeiculo;
        private float LitrosAbastecidos;

        public void LerConsumo()
        {
            Console.WriteLine("Entre com o consumo do veículo em Km/L: ");
            if (!float.TryParse(Console.ReadLine(), out ConsumoVeiculo))    // verifica se é um float
            {
                Console.WriteLine("Valor Inválido");
            }
            ValidaValor(ConsumoVeiculo);
        }

        public void LerLitrosAbastecidos()
        {
            Console.WriteLine("Entre com a quantidade de litros abastecida: ");
            if (!float.TryParse(Console.ReadLine(), out LitrosAbastecidos))
            {
                Console.WriteLine("Valor Inválido");
            }
            ValidaValor(LitrosAbastecidos);
        }

        private void ValidaValor(float valor)   // verifica se o valor é menor que 0
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor Inválido");
            }
        }

        public void ExibirResultado()
        {
            Console.WriteLine("\nA quantidade de quilometros máxima rodada é: {0:N0} Km/L", LitrosAbastecidos * ConsumoVeiculo);
        }
    }
}
