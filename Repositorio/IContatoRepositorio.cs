using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public interface IContatoRepositorio
    {
        List<Contato> BuscarTodos();
        Contato Adicionar(Contato contato);
    }
}
