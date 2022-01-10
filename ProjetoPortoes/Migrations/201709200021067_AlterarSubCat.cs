namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarSubCat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubCategorias", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategorias", "Imagem", c => c.String(nullable: false));
        }
    }
}
