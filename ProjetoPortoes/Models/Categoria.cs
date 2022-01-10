using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(3000, ErrorMessage = ("No máximo 3000 caracteres"))]
        [Display(Name = "Descrição da Categoria")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public List<SubCategoria> SubCategoria { get; set; }
    }
}