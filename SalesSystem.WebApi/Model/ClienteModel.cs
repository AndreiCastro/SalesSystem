using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SalesSystem.WebApi.Model
{
    public class ClienteModel
    {
        [Key()]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]        
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        public string CpfCnpj { get; set; }

        [Required]
        [StringLength(30)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(20)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(2)]
        public string Uf { get; set; }

        [Required]
        [StringLength(10)]
        public string Cep { get; set; }

        [Required]
        [StringLength(20)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(14)]
        public string Telefone { get; set; }
    }
}
