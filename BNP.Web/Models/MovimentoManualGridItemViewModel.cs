using System;

namespace BNP.Web.Models
{
    public class MovimentoManualGridItemViewModel
    {
        public int NumeroLancamento { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Usuario { get; set; }
        public DateTime DataMovimento { get; set; }
    }
}