using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Entities
{
    public class MovimentoManual
    {
        public int Mes { get; set; }                
        public int Ano { get; set; }                
        public int NumeroLancamento { get; set; }   

        public string CodigoProduto { get; set; }   
        public string CodigoCosif { get; set; }     

        public string Descricao { get; set; }       
        public decimal Valor { get; set; }          
        public DateTime DataMovimento { get; set; } 
        public string Usuario { get; set; } 

        public virtual Produto Produto { get; set; }
        public virtual ProdutoCosif ProdutoCosif { get; set; }
    }
}
