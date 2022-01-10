namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caracteristicas", "Produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.Caracteristicas", new[] { "Produto_ProdutoId" });
            DropColumn("dbo.Caracteristicas", "ProdutoId");
            RenameColumn(table: "dbo.Caracteristicas", name: "Produto_ProdutoId", newName: "ProdutoId");
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Caracteristicas", "ProdutoId");
            AddForeignKey("dbo.Caracteristicas", "ProdutoId", "dbo.Produtos", "ProdutoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caracteristicas", "ProdutoId", "dbo.Produtos");
            DropIndex("dbo.Caracteristicas", new[] { "ProdutoId" });
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.Int());
            AlterColumn("dbo.Caracteristicas", "ProdutoId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Caracteristicas", name: "ProdutoId", newName: "Produto_ProdutoId");
            AddColumn("dbo.Caracteristicas", "ProdutoId", c => c.String(nullable: false));
            CreateIndex("dbo.Caracteristicas", "Produto_ProdutoId");
            AddForeignKey("dbo.Caracteristicas", "Produto_ProdutoId", "dbo.Produtos", "ProdutoId");
        }
    }
}
