using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace SalesSystem.WebApi.Model
{
    public class VendaModel
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }
        
        [Required(ErrorMessage = "Quantidade é obrigatória.")]
        [DisplayName("Quantidade")]
        public int QuantidadeProduto { get; set; }

        [Required]
        public decimal ValorTotal { get; set; }
                
        [DisplayName("Descrição")]
        [StringLength(100, ErrorMessage = "{0} deve conter {1} caracteres.")]
        public string Descricao { get; set; }

        public decimal? Desconto { get; set; }


        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual ClienteModel Cliente { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }
        public virtual ProdutoModel Produto { get; set; }
    }
}
