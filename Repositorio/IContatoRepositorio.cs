using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> BuscarTodos();
        Contato ListarPorId(int id);
        Contato Adicionar(Contato contato);
        Contato Atualizar(Contato contato);

        bool Deletar(int id);

    }
}
