namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class excluirQuantidadeCarac : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Caracteristicas", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caracteristicas", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
