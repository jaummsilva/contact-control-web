using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class Contato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o email do Contato")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do Contato")]
        [Phone(ErrorMessage = "O celular informado não é válido")]
        public string Celular { get; set; }

    }
}
