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
    public class MovimentoManualRepository : IMovimentoManualRepository
    {
        private readonly BNPDbContext _ctx;
        public MovimentoManualRepository(BNPDbContext ctx) => _ctx = ctx;

        public IEnumerable<MovimentoManual> ObterPorMesAno(int mes, int ano) =>
            _ctx.MovimentosManuais.Where(m => m.Mes == mes && m.Ano == ano)
                                  .OrderBy(m => m.NumeroLancamento)
                                  .ToList();

        public int ObterProximoNumeroLancamento(int mes, int ano)
        {
            var max = _ctx.MovimentosManuais
                          .Where(m => m.Mes == mes && m.Ano == ano)
                          .Select(m => (int?)m.NumeroLancamento)
                          .Max();
            return (max ?? 0) + 1;
        }

        public void Adicionar(MovimentoManual movimento) => _ctx.MovimentosManuais.Add(movimento);
        public void Salvar() => _ctx.SaveChanges();
    }
}
