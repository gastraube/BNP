using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BNP.Web.Models
{
    public class MovimentoManualViewModel
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public IEnumerable<SelectListItem> Produtos { get; set; }
        public IEnumerable<SelectListItem> Cosifs { get; set; }

        public List<MovimentoManualGridItemViewModel> Grid { get; set; }
    }
}