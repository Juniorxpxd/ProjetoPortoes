using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Administradores")]
    public class Administrador
    {
        [Key]
        public int AdmId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Nome do Administrador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}