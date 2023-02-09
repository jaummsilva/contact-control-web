using ContatosMVC.Data;
using ContatosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContatosMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.setSenhaHash();
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização do contato");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAlteracao = DateTime.Now;

            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }
        public bool Deletar(int id)
        {
            Usuario usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro na exclusão do contato");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }
        public List<Usuario> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public Usuario ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorEmailLogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }
    }
}
