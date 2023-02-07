using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string LoginEntrar  { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }
    }
}
