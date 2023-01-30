using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Domain.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime NascimentoFuncionario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string NumeroTelefone { get; set; } 
        public string Email { get; set; }
    }
}
