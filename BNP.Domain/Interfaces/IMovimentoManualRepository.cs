using BNP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Domain.Interfaces
{
    public interface IMovimentoManualRepository
    {
        IEnumerable<MovimentoManual> ObterPorMesAno(int mes, int ano);
        int ObterProximoNumeroLancamento(int mes, int ano);
        void Adicionar(MovimentoManual movimento);
        void Salvar();
    }

    public interface IProdutoRepository
    {
        IEnumerable<Produto> ObterTodos();
    }

    public interface IProdutoCosifRepository
    {
        IEnumerable<ProdutoCosif> ObterPorProduto(string codProduto);
    }
}
