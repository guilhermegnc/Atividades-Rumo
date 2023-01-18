using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa4
{
    public class Fluxo
    {
        private decimal _preçoKW;
        private int _potenciaDispositivo;
        private decimal _tempoLigado;
        private int _diasLigado;
        private decimal _valorAPagar;


        private void EntradaDeDados()
        {
            Console.WriteLine("Entre com o preço do KiloWatt");
            if (!decimal.TryParse(Console.ReadLine(), out _preçoKW) || _preçoKW < 0)
            {
                Console.WriteLine("Preço Inválido");
                return;
            }

            Console.WriteLine("\nEntre com a potência do dispositivo em Watts");
            if (!int.TryParse(Console.ReadLine(), out _potenciaDispositivo) || _potenciaDispositivo <= 0)
            {
                Console.WriteLine("Potência do Dispositivo é Inválido");
                return;
            }

            Console.WriteLine("\nEntre com a quantidade de horas que o dispositivo fica ligado ao dia");
            if (!decimal.TryParse(Console.ReadLine(), out _tempoLigado) || _tempoLigado < 0.0M || _tempoLigado > 24.0M)
            {
                Console.WriteLine("Tempo Inválido");
                return;
            }

            Console.WriteLine("\nEntre com a quantidade de dias que o dispositivo fica ligado no mês");
            if (!int.TryParse(Console.ReadLine(), out _diasLigado) || _diasLigado < 0 || _diasLigado > 31)
            {
                Console.WriteLine("Quantidade de dias é inválida");
                return;
            }
        }

        public void CalculaExibe()
        {
            EntradaDeDados();

            var ConsumoDispositivo = _potenciaDispositivo * _tempoLigado / 1000;
            _valorAPagar = ConsumoDispositivo * _preçoKW * _diasLigado;

            Console.Clear();

            Console.WriteLine("O valor a pagar ao final do mês é: {0:N2} Reais", _valorAPagar);
        }
    }
}
