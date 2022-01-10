using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoPortoes.Models
{
    [Table("Caracteristicas")]
    public class Caracteristicas
    {
        [Key]
        public int CaracteristicaId { get; set; }

        public Produto Produto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome do Produto")]
        public int ProdutoId { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Alimentação (Motor)")]
        public string Alimentacao { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Motor")]
        public string Motor { get; set; }

        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Potência Nominal (Motor)")]
        public string PotenciaMotor { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Peso do Portão (Motor)")]
        public string PesoPortao { get; set; }

        [MaxLength(200, ErrorMessage = ("No máximo 200 caracteres"))]
        [Display(Name = "Consumo (Motor)")]
        public string Consumo { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Frequência (Motor)")]
        public string Frequencia { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Rotação do Motor (Motor)")]
        public string RotacaoMotor { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Coroa Interna (Motor)")]
        public string CoroaInterna { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Fim de Curso (Motor)")]
        public string FimDeCurso { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Capacitor (Motor)")]
        public string Capacitor { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Velocidade de Abertura (Motor/Porta)")]
        public string VelocidadeAbertura { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Carga Máxima (Porta)")]
        public string CargaMaxima { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Versões (Porta)")]
        public string Versoes { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Fixação (Porta)")]
        public string Fixacao { get; set; }

        [MaxLength(100, ErrorMessage = ("No máximo 100 caracteres"))]
        [Display(Name = "Tamanho do Trilho (Porta)")]
        public string TamanhoTrilho { get; set; }

        [Display(Name = "Quantidade de Ciclos/Hora")]
        public int QuantidadeCiclosHora { get; set; }
    }
}