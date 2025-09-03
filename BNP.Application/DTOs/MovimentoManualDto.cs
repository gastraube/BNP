using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Application.DTOs
{
    public class MovimentoManualDto
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
