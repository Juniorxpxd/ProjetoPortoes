using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        public SubCategoria SubCategoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome da SubCategoria")]
        public int SubCategoriaId { get; set; }

        public List<Caracteristicas> Caracteristicas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(1000, ErrorMessage = ("No máximo 1000 caracteres"))]
        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço do Produto")]
        public double Preco { get; set; }

        [Display(Name = "Quantidade de Produtos")]
        public int Quantidade { get; set; }

        [Display(Name = "Imagem do Produto")]
        [DataType(DataType.Upload)]
        public string Imagem { get; set; }
    }
}