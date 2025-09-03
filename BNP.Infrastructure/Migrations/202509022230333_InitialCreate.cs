namespace BNP.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovimentoManuals",
                c => new
                    {
                        DAT_MES = c.Int(nullable: false),
                        DAT_ANO = c.Int(nullable: false),
                        NUM_LANCAMENTO = c.Int(nullable: false),
                        COD_PRODUTO = c.String(maxLength: 128),
                        COD_COSIF = c.String(maxLength: 128),
                        DES_DESCRICAO = c.String(),
                        VAL_VALOR = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DAT_MOVIMENTO = c.DateTime(nullable: false),
                        COD_USUARIO = c.String(),
                        Produto_Codigo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DAT_MES, t.DAT_ANO, t.NUM_LANCAMENTO })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Codigo)
                .ForeignKey("dbo.ProdutoCosifs", t => new { t.COD_PRODUTO, t.COD_COSIF })
                .Index(t => new { t.COD_PRODUTO, t.COD_COSIF })
                .Index(t => t.Produto_Codigo);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        COD_PRODUTO = c.String(nullable: false, maxLength: 128),
                        DES_PRODUTO = c.String(),
                    })
                .PrimaryKey(t => t.COD_PRODUTO);
            
            CreateTable(
                "dbo.ProdutoCosifs",
                c => new
                    {
                        COD_PRODUTO = c.String(nullable: false, maxLength: 128),
                        COD_COSIF = c.String(nullable: false, maxLength: 128),
                        COD_CLASSIFICACAO = c.String(),
                        Produto_Codigo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.COD_PRODUTO, t.COD_COSIF })
                .ForeignKey("dbo.Produtoes", t => t.Produto_Codigo)
                .Index(t => t.Produto_Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovimentoManuals", new[] { "COD_PRODUTO", "COD_COSIF" }, "dbo.ProdutoCosifs");
            DropForeignKey("dbo.MovimentoManuals", "Produto_Codigo", "dbo.Produtoes");
            DropForeignKey("dbo.ProdutoCosifs", "Produto_Codigo", "dbo.Produtoes");
            DropIndex("dbo.ProdutoCosifs", new[] { "Produto_Codigo" });
            DropIndex("dbo.MovimentoManuals", new[] { "Produto_Codigo" });
            DropIndex("dbo.MovimentoManuals", new[] { "COD_PRODUTO", "COD_COSIF" });
            DropTable("dbo.ProdutoCosifs");
            DropTable("dbo.Produtoes");
            DropTable("dbo.MovimentoManuals");
        }
    }
}
