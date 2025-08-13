using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeAPI.Models
{
    //[Table("Cliente")]
    public class Cliente
    {
        //[Column("IdCliente")]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}
