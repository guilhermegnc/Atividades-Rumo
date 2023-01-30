﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPonto.Domain.Models
{
    public class Ponto
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHorarioPonto { get; set; }
        public string? Justificativa { get; set; }
    }
}
