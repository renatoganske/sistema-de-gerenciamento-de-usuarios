using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LyncasAPI.Models
{
    public class Autenticacao
    {
        public int UserId { get; set; }
        [Key]
        public int IdPessoaAutenticacao { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$",
            ErrorMessage = "A senha deve conter pelo menos 6 caracteres com pelo menos um número.")]
        public string Senha { get; set; } = string.Empty;
        public Boolean Status { get; set; }
        [JsonIgnore]
        public Pessoa? User { get; set; }
    }
}
