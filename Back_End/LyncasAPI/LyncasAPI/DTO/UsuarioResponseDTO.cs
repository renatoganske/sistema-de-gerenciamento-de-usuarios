using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LyncasAPI.DTO
{
    public class UsuarioResponseDTO
    {
        [Required]
        [Key]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o nome.")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o sobrenome.")]
        [MaxLength(100)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o e-mail.")]
        [MaxLength(100)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
            ErrorMessage = "Digite um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o telefone.")]
        [MaxLength(15)]
        [RegularExpression(@"[0-9]{2}([9]{1})?([0-9]{4})([0-9]{4})$",
            ErrorMessage = "Digite um telefone válido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a data de nascimento.")]
        [Column(TypeName = "Date")]
        public DateTime DataDeNascimento { get; set; }
        public Boolean Status { get; set; }
    }
}
