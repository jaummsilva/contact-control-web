using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> BuscarTodos(int usuarioId);
        List<Contato> BuscarTodosAdmin();
        Contato ListarPorId(int id);
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);

        bool Deletar(int id);

    }
}
