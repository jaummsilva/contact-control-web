using ContatosMVC.Enums;
using ContatosMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro  { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        public void setSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
