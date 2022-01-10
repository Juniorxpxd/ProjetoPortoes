namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Caracteristicas", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Caracteristicas", "Imagem", c => c.String(nullable: false));
        }
    }
}
