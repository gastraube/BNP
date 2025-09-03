using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Entities
{
    public class ProdutoCosif
    {
        public string CodigoProduto { get; set; }   
        public string CodigoCosif { get; set; }  
        public string CodigoClassificacao { get; set; } 

        public virtual Produto Produto { get; set; }
    }
}
