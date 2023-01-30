using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Domain.Models
{
    public class Lideranca
    {   
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public string Descricao { get; set; }
    }
}
