using ContatosMVC.Data;
using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Contato Adicionar(Contato contato)
        {
           _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public List<Contato> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
    }
}
