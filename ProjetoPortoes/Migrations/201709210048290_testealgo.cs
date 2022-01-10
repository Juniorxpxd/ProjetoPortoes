namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testealgo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caracteristicas", "ProdutoId", "dbo.Produtos");
            DropIndex("dbo.Caracteristicas", new[] { "ProdutoId" });
            AddColumn("dbo.Caracteristicas", "Produto_ProdutoId", c => c.Int());
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.String(nullable: false));
            CreateIndex("dbo.Caracteristicas", "Produto_ProdutoId");
            AddForeignKey("dbo.Caracteristicas", "Produto_ProdutoId", "dbo.Produtos", "ProdutoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caracteristicas", "Produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.Caracteristicas", new[] { "Produto_ProdutoId" });
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.Int(nullable: false));
            DropColumn("dbo.Caracteristicas", "Produto_ProdutoId");
            CreateIndex("dbo.Caracteristicas", "ProdutoId");
            AddForeignKey("dbo.Caracteristicas", "ProdutoId", "dbo.Produtos", "ProdutoId", cascadeDelete: true);
        }
    }
}
