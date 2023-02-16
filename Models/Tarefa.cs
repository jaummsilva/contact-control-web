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
        public DateTime DataFinal { get; set; }
        public TarefaEnum? TarefaEnum { get; set; }

        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
