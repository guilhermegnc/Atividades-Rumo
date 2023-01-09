﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade4
{
    public class CalculadoraDeLucros
    {
        private List<String> Produto = new List<String>();
        private List<int> Quantidade = new List<int>();
        private List<float> ValorVenda = new List<float>();
        private List<float> ValorCompra = new List<float>();
        private List<float> Lucro = new List<float>();

        public void EntradaDeDados()
        {
            while (true)
            {
                Console.WriteLine("Entre com o nome do produto: ");

                String? NomeProduto = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(NomeProduto))
                {
                    Console.WriteLine("Nome Inválido");
                    continue;
                }

                Console.WriteLine("Entre com a quantidade do produto: ");
                int QuantidadeProduto;
                if (!int.TryParse(Console.ReadLine(), out QuantidadeProduto) || QuantidadeProduto < 0)
                {
                    Console.WriteLine("Valor Inválido");
                    continue;
                }

                Console.WriteLine("Entre com o valor de compra do produto: ");
                float ValorDaCompraProduto;
                if (!float.TryParse(Console.ReadLine(), out ValorDaCompraProduto) || ValorDaCompraProduto < 0)
                {
                    Console.WriteLine("Valor Inválido");
                    continue;
                }

                Console.WriteLine("Entre com o valor de venda do produto: ");
                float ValorDaVendaProduto;
                if (!float.TryParse(Console.ReadLine(), out ValorDaVendaProduto) || ValorDaVendaProduto < 0)
                {
                    Console.WriteLine("Valor Inválido");
                    continue;
                }

                Produto.Add(NomeProduto);
                Quantidade.Add(QuantidadeProduto);
                ValorCompra.Add(ValorDaCompraProduto);
                ValorVenda.Add(ValorDaVendaProduto);

                Console.WriteLine("\n\nAdicionar mais um produto?\n0-Não\n1-Sim");
                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 0 || opcao > 1)
                {
                    Console.WriteLine("Valor Inválido");
                    continue;
                }

                Console.Clear();

                if (opcao == 0) break;
            }
        }

        public void CalculaLucro()
        {
            for (int i=0; i <Produto.Count(); i++)
            {
                Lucro.Add((float)((ValorVenda[i] * Quantidade[i]) - (ValorCompra[i] * Quantidade[i]) * 0.8));
            }
        }

        public void ExibeLucro()
        {
            Console.WriteLine(String.Format("|{0,10}|{1,15}|{2,20}|{3,20}|{4,10}|", "Produtos", "Quantidade", "Valor de Compra (R$)", "Valor de Venda (R$)", "Lucro (R$)"));
            Console.WriteLine(String.Concat(Enumerable.Repeat("-", 77)));
            for (int i = 0; i < Produto.Count(); i++)
            {
                String linha = String.Format("|{0,10}|{1,15}|{2,20:N2}|{3,20:N2}|{4,10:N2}|", Produto[i], Quantidade[i], ValorCompra[i], ValorVenda[i], Lucro[i]);
                Console.WriteLine(linha);
            }
                
        }
    }
}
