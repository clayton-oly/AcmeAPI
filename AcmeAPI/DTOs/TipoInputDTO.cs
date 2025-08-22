using System.ComponentModel.DataAnnotations;

namespace AcmeAPI.DTOs
{
    public class TipoInputDTO
    {
        [Required(ErrorMessage = "Nome do Tipo é obrigatorio")]
        public string Nome { get; set; }
    }
}
