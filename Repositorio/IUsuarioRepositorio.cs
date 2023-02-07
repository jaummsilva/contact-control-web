using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscarPorLogin(string login);
        List<Usuario> BuscarTodos();
        Usuario ListarPorId(int id);
        Usuario Adicionar(Usuario usuario);
        Usuario Atualizar(Usuario usuario);

        bool Deletar(int id);
    }
}
