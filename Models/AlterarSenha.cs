using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class AlterarSenha
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a senha nova")]
        public string SenhaNova { get; set; }
        
        [Required(ErrorMessage = "Confirme a senha nova")]
        [Compare("SenhaNova", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmarSenhaNova { get; set; }

    }
}
