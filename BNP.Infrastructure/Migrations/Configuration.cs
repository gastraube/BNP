namespace BNP.Infrastructure.Migrations
{
    using BNP.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BNP.Infrastructure.Context.BNPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BNP.Infrastructure.Context.BNPDbContext context)
        {
            context.Set<Produto>().AddOrUpdate(p => p.Codigo,
                  new Produto { Codigo = "P001", Descricao = "Produto 1" },
                  new Produto { Codigo = "P002", Descricao = "Produto 2" }
             );

            context.Set<ProdutoCosif>().AddOrUpdate(pc => new { pc.CodigoProduto, pc.CodigoCosif },
                new ProdutoCosif { CodigoProduto = "P001", CodigoCosif = "C001", CodigoClassificacao = "CL1" },
                new ProdutoCosif { CodigoProduto = "P002", CodigoCosif = "C002", CodigoClassificacao = "CL2" }
            );

            context.Set<MovimentoManual>().AddOrUpdate(m => new { m.Mes, m.Ano, m.NumeroLancamento },
                new MovimentoManual
                {
                    Mes = 1,
                    Ano = 2025,
                    NumeroLancamento = 1,
                    CodigoProduto = "P001",
                    CodigoCosif = "C001",
                    Descricao = "Lançamento teste",
                    Valor = 123.45m,
                    DataMovimento = DateTime.Now,
                    Usuario = "TESTE"
                }
            );

            context.SaveChanges();
        }
    }
}
