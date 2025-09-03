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
    public class ProdutoCosifRepository : IProdutoCosifRepository
    {
        private readonly BNPDbContext _ctx;
        public ProdutoCosifRepository(BNPDbContext ctx) => _ctx = ctx;

        public IEnumerable<ProdutoCosif> ObterPorProduto(string codProduto) =>
            _ctx.ProdutoCosifs.Where(x => x.CodigoProduto == codProduto)
                              .OrderBy(x => x.CodigoCosif).ToList();
    }
}
