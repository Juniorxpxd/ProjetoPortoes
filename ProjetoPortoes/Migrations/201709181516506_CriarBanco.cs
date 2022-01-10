namespace ProjetoPortoes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        AdmId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 200),
                        Senha = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.AdmId);
            
            CreateTable(
                "dbo.Caracteristicas",
                c => new
                    {
                        CaracteristicaId = c.Int(nullable: false, identity: true),
                        ProdutoId = c.String(nullable: false),
                        Imagem = c.String(nullable: false),
                        Alimentacao = c.String(maxLength: 100),
                        Motor = c.String(maxLength: 100),
                        PotenciaMotor = c.String(maxLength: 200),
                        PesoPortao = c.String(maxLength: 100),
                        Consumo = c.String(maxLength: 200),
                        Frequencia = c.String(maxLength: 100),
                        RotacaoMotor = c.String(maxLength: 100),
                        CoroaInterna = c.String(maxLength: 100),
                        FimDeCurso = c.String(maxLength: 100),
                        Capacitor = c.String(maxLength: 100),
                        VelocidadeAbertura = c.String(maxLength: 100),
                        CargaMaxima = c.String(maxLength: 100),
                        Versoes = c.String(maxLength: 100),
                        Fixacao = c.String(maxLength: 100),
                        TamanhoTrilho = c.String(maxLength: 100),
                        Quantidade = c.Int(nullable: false),
                        QuantidadeCiclosHora = c.Int(nullable: false),
                        Produto_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.CaracteristicaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId)
                .Index(t => t.Produto_ProdutoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        SubCategoriaId = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 1000),
                        Preco = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        SubCategoria_SubCategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.SubCategorias", t => t.SubCategoria_SubCategoriaId)
                .Index(t => t.SubCategoria_SubCategoriaId);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        SubCategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaId = c.String(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 3000),
                        Imagem = c.String(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoriaId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(nullable: false, maxLength: 3000),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ItemVendas",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        ProdutoId = c.String(nullable: false),
                        CarrinhoId = c.String(),
                        Preco = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DataDaAdicao = c.DateTime(nullable: false),
                        Produto_ProdutoId = c.Int(),
                        Venda_VendaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId)
                .ForeignKey("dbo.Vendas", t => t.Venda_VendaId)
                .Index(t => t.Produto_ProdutoId)
                .Index(t => t.Venda_VendaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 1000),
                        Login = c.String(nullable: false, maxLength: 200),
                        Senha = c.String(nullable: false, maxLength: 200),
                        Telefone = c.String(nullable: false, maxLength: 15),
                        Estado = c.String(nullable: false, maxLength: 200),
                        Cidade = c.String(nullable: false, maxLength: 200),
                        Endereco = c.String(nullable: false, maxLength: 300),
                        Complemento = c.String(maxLength: 20),
                        Numero = c.String(nullable: false, maxLength: 10),
                        CEP = c.String(nullable: false, maxLength: 15),
                        CPF = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        VendaId = c.Int(nullable: false, identity: true),
                        DataDaVenda = c.DateTime(nullable: false),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.VendaId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Usuario_UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ItemVendas", "Venda_VendaId", "dbo.Vendas");
            DropForeignKey("dbo.ItemVendas", "Produto_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "SubCategoria_SubCategoriaId", "dbo.SubCategorias");
            DropForeignKey("dbo.SubCategorias", "Categoria_CategoriaId", "dbo.Categorias");
            DropForeignKey("dbo.Caracteristicas", "Produto_ProdutoId", "dbo.Produtos");
            DropIndex("dbo.Vendas", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.ItemVendas", new[] { "Venda_VendaId" });
            DropIndex("dbo.ItemVendas", new[] { "Produto_ProdutoId" });
            DropIndex("dbo.SubCategorias", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.Produtos", new[] { "SubCategoria_SubCategoriaId" });
            DropIndex("dbo.Caracteristicas", new[] { "Produto_ProdutoId" });
            DropTable("dbo.Vendas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.ItemVendas");
            DropTable("dbo.Categorias");
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Produtos");
            DropTable("dbo.Caracteristicas");
            DropTable("dbo.Administradores");
        }
    }
}
