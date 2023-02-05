using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRP.Domains.Models
{
    public enum EnumCargoUsuario
    {
        Funcionario = 1,
        Cliente
    }

    public class Usuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public EnumCargoUsuario CargoUsuario { get; set; }
    }
}
