using BNP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNP.Infrastructure.Context
{
    public class BNPDbContext : DbContext
    {
        public BNPDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoCosif> ProdutoCosifs { get; set; }
        public DbSet<MovimentoManual> MovimentosManuais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Codigo)
                .Property(p => p.Codigo)
                .HasColumnName("COD_PRODUTO");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasColumnName("DES_PRODUTO");

            modelBuilder.Entity<ProdutoCosif>()
                .HasKey(pc => new { pc.CodigoProduto, pc.CodigoCosif });

            modelBuilder.Entity<ProdutoCosif>()
                .Property(pc => pc.CodigoProduto)
                .HasColumnName("COD_PRODUTO");

            modelBuilder.Entity<ProdutoCosif>()
                .Property(pc => pc.CodigoCosif)
                .HasColumnName("COD_COSIF");

            modelBuilder.Entity<ProdutoCosif>()
                .Property(pc => pc.CodigoClassificacao)
                .HasColumnName("COD_CLASSIFICACAO");

            modelBuilder.Entity<MovimentoManual>()
                .HasKey(m => new { m.Mes, m.Ano, m.NumeroLancamento });

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.Mes)
                .HasColumnName("DAT_MES");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.Ano)
                .HasColumnName("DAT_ANO");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.NumeroLancamento)
                .HasColumnName("NUM_LANCAMENTO");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.CodigoProduto)
                .HasColumnName("COD_PRODUTO");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.CodigoCosif)
                .HasColumnName("COD_COSIF");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.Descricao)
                .HasColumnName("DES_DESCRICAO");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.Valor)
                .HasColumnName("VAL_VALOR");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.DataMovimento)
                .HasColumnName("DAT_MOVIMENTO");

            modelBuilder.Entity<MovimentoManual>()
                .Property(m => m.Usuario)
                .HasColumnName("COD_USUARIO");

            base.OnModelCreating(modelBuilder);
        }
    }
}
