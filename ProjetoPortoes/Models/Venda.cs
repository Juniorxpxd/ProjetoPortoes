using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }
        public Usuario Usuario { get; set; }
        public List<ItemVenda> Itens { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        public DateTime DataDaVenda { get; set; }

        [ScaffoldColumn(false)]
        public string CarrinhoId { get; set; }
    }
}