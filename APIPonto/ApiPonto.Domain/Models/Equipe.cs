using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Domain.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public int LiderancaId { get; set; }
        public int FuncionarioId { get; set; }
    }
}
