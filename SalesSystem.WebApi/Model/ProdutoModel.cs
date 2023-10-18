using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.WebApi.Model
{
    public class ProdutoModel
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]
        [MinLength(3)]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(3)]
        public string UnidadeMedida { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]    
        public int Peso { get; set; }

        [Required]
        public DateTime DataValidade { get; set; }
    }
}
