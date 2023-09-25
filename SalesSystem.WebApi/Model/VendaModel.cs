using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace SalesSystem.WebApi.Model
{
    public class VendaModel
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        public DateTime DataVenda { get; set; }
        
        [Required(ErrorMessage = "Quantidade do Produto é obrigatório.")]
        [DisplayName("Quantidade de Produto")]
        public int QuantidadeProduto { get; set; }

        [Required(ErrorMessage = "Valor Total é obrigatório.")]
        public decimal ValorTotal { get; set; }
                
        [DisplayName("Descrição")]
        [StringLength(100, ErrorMessage = "Descrição não pode ultrapassar {1} caracteres.")]
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
