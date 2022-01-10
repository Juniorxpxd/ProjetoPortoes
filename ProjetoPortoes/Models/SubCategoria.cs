using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("SubCategorias")]
    public class SubCategoria
    {
        [Key]
        public int SubCategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Nome da SubCategoria")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(3000, ErrorMessage = ("No máximo 3000 caracteres"))]
        [Display(Name = "Descrição da SubCategoria")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Imagem da SubCategoria")]
        [DataType(DataType.Upload)]
        public string Imagem { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}