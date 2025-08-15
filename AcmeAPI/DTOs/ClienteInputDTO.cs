using System.ComponentModel.DataAnnotations;

namespace AcmeAPI.DTOs
{
    public class ClienteInputDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF é obrigatorio")]
        [Length(14, 14, ErrorMessage = "CPF deve ter emtre 11 e 14 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatorio")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Email é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
    }
}
