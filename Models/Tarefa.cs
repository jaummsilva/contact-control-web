using ContatosMVC.Enums;
using ContatosMVC.Helpers;
using System.ComponentModel.DataAnnotations;

namespace ContatosMVC.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a descrição da tarefa")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "Digite a data final da tarefa")]
        public DateTime DataFinal { get; set; }
        [Required(ErrorMessage = "Escolha o status de andamento da tarefa")]
        public TarefaEnum? TarefaEnum { get; set; }

        [Required(ErrorMessage = "Digite o id do usuario da tarefa")]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
