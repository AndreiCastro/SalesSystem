using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Numerics;

namespace SalesSystem.WebApi.Model
{
    public class ProdutoModel
    {
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [DisplayName("Descrição")]
        [MinLength(3, ErrorMessage = "Descrição deve conter no mínino {1} caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório.")]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Unidade de Medida é obrigatória.")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "{0} deve conter {1}.")]
        [DisplayName("Unid. Medida")]
        public string UnidadeMedida { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória.")]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]        
        public int Peso { get; set; }

        [Required(ErrorMessage = "Data de Validade é obrigatória.")]
        [DisplayName("Data de Validade")]
        public DateTime DataValidade { get; set; }
    }
}
