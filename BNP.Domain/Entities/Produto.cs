using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Entities
{
    public class Produto
    {
        public string Codigo { get; set; } 
        public string Descricao { get; set; }

        public virtual ICollection<ProdutoCosif> ProdutoCosifs { get; set; }

        public Produto()
        {
            ProdutoCosifs = new List<ProdutoCosif>();
        }
    }
}
