namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarSubCategoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategorias", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.SubCategorias", new[] { "Categoria_CategoriaId" });
            DropColumn("dbo.SubCategorias", "CategoriaId");
            RenameColumn(table: "dbo.SubCategorias", name: "Categoria_CategoriaId", newName: "CategoriaId");
            AlterColumn("dbo.SubCategorias", "CategoriaId", c => c.Int(nullable: false));
            AlterColumn("dbo.SubCategorias", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCategorias", "CategoriaId");
            AddForeignKey("dbo.SubCategorias", "CategoriaId", "dbo.Categorias", "CategoriaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategorias", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.SubCategorias", new[] { "CategoriaId" });
            AlterColumn("dbo.SubCategorias", "CategoriaId", c => c.Int());
            AlterColumn("dbo.SubCategorias", "CategoriaId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.SubCategorias", name: "CategoriaId", newName: "Categoria_CategoriaId");
            AddColumn("dbo.SubCategorias", "CategoriaId", c => c.String(nullable: false));
            CreateIndex("dbo.SubCategorias", "Categoria_CategoriaId");
            AddForeignKey("dbo.SubCategorias", "Categoria_CategoriaId", "dbo.Categorias", "CategoriaId");
        }
    }
}
