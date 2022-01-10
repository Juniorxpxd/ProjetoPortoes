using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("ItemVendas")]
    public class ItemVenda
    {
        [Key]
        public int ItemVendaId { get; set; }
        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public int ProdutoId { get; set; }

        [ScaffoldColumn(false)]
        public string CarrinhoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Preço do Produto")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime DataDaAdicao { get; set; }
    }
}