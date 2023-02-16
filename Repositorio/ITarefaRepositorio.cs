using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public interface ITarefaRepositorio
    {
        List<Tarefa> BuscarTodos(int usuarioId);
        List<Tarefa> BuscarTodosAdmin();
        Tarefa ListarPorId(int id);
        Tarefa Adicionar(Tarefa tarefa);
        Tarefa Atualizar(Tarefa tarefa);

        bool Deletar(int id);

    }
}
