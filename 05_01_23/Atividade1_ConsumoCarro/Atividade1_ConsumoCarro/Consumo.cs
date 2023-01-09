using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1_ConsumoCarro
{
    public class Consumo
    {

        private float CapacidadeTanque;
        private float QuilometrosRodados;

        public void LerCapacidadeTanque()
        {
            Console.WriteLine("Entre com a capacidade do tanque do veículo: ");
            if (!float.TryParse(Console.ReadLine(), out CapacidadeTanque))
            {
                Console.WriteLine("Valor Inválido");
            }
            ValidaValor(CapacidadeTanque);
        }

        public void LerQuilometrosRodados()
        {
            Console.WriteLine("Entre com a quantidade de quilômetros rodados: ");
            if (!float.TryParse(Console.ReadLine(), out QuilometrosRodados))
            {
                Console.WriteLine("Valor Inválido");
            }
            ValidaValor(QuilometrosRodados);
        }

        private void ValidaValor(float valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("Valor Inválido");
            }
        }

        public void ExibirResultado()
        {
            Console.WriteLine("\nO consumo do veículo é: {0:N2} Km/L", QuilometrosRodados / CapacidadeTanque);
        }
    }
}
