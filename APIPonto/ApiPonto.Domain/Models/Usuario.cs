using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Domain.Models
{
    public enum EnumCargoUsuario
    {
        RH = 1,
        Gerente,
        Colaborador
    }

    public class Usuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public EnumCargoUsuario CargoUsuario { get; set; }
    }
}
