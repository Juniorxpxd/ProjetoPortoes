using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(1000, ErrorMessage = ("No máximo 1000 caracteres"))]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Confirmação da Senha")]
        [DataType(DataType.Password)]
        [Compare("Senha",ErrorMessage = "Os campos não coincidem!")]
        [NotMapped]
        public string ConfSenha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = ("No máximo 15 caracteres"))]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(300, ErrorMessage = ("No máximo 300 caracteres"))]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [MaxLength(20, ErrorMessage = ("No máximo 20 caracteres"))]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(10, ErrorMessage = ("No máximo 10 caracteres"))]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = ("No máximo 15 caracteres"))]
        [Display(Name = "CEP")]
        [DataType(DataType.PostalCode)]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = ("No máximo 15 caracteres"))]
        [Display(Name = "CPF")]
        public string CPF { get; set; }
    }
}