using BNP.Domain.Entities;
using BNP.Domain.Interfaces;
using BNP.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly BNPDbContext _ctx;
        public ProdutoRepository(BNPDbContext ctx) => _ctx = ctx;
        public IEnumerable<Produto> ObterTodos() => _ctx.Produtos.OrderBy(p => p.Descricao).ToList();
    }
}
