using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SalesSystem.WebApi.Model
{
    public class ClienteModel
    {
        [Key()]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail com formato inválido.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ é obrigatório.")]
        [DisplayName("CPF/CNPJ")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "CPF/CNPJ deve conter de {2} a {1} caracteres.")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "UF é obrigatório.")]
        [StringLength(2, ErrorMessage = "{0} deve conter {1} caracteres.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [StringLength(10, ErrorMessage = "CEP não pode ultrapassar {1} caracteres.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "{0} deve conter de {2} a {1} caracteres.")]
        public string Telefone { get; set; }


        #region NotMapped
        [NotMapped]
        [Compare("Email", ErrorMessage = "E-mail informado é diferente do campo E-mail")]
        public string ComparaEmail { get; set; }
        #endregion NotMapped
    }
}
