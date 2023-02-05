using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRP.Domains.Models
{
    public class ListaProdutos
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Situacao { get; set; }
        public decimal? DiferencaPreco { get; set; }
        public decimal? PorcentagemDiferenca { get; set; }
    }
}
