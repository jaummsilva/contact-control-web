using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class RedefinirSenha
    {
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string LoginEntrar { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        public string Email { get; set; }
    }
}
