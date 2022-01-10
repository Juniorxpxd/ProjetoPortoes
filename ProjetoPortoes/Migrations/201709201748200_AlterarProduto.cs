namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarProduto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produtos", "SubCategoria_SubCategoriaId", "dbo.SubCategorias");
            DropIndex("dbo.Produtos", new[] { "SubCategoria_SubCategoriaId" });
            DropColumn("dbo.Produtos", "SubCategoriaId");
            RenameColumn(table: "dbo.Produtos", name: "SubCategoria_SubCategoriaId", newName: "SubCategoriaId");
            AlterColumn("dbo.Produtos", "SubCategoriaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Produtos", "SubCategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtos", "SubCategoriaId");
            AddForeignKey("dbo.Produtos", "SubCategoriaId", "dbo.SubCategorias", "SubCategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "SubCategoriaId", "dbo.SubCategorias");
            DropIndex("dbo.Produtos", new[] { "SubCategoriaId" });
            AlterColumn("dbo.Produtos", "SubCategoriaId", c => c.Int());
            AlterColumn("dbo.Produtos", "SubCategoriaId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Produtos", name: "SubCategoriaId", newName: "SubCategoria_SubCategoriaId");
            AddColumn("dbo.Produtos", "SubCategoriaId", c => c.String(nullable: false));
            CreateIndex("dbo.Produtos", "SubCategoria_SubCategoriaId");
            AddForeignKey("dbo.Produtos", "SubCategoria_SubCategoriaId", "dbo.SubCategorias", "SubCategoriaId");
        }
    }
}
