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

        public Contato Atualizar(Contato contato)
        {
            Contato contadoDB = ListarPorId(contato.Id);
            
            if (contadoDB == null) throw new Exception("Houve um erro na atualização do contato");
            
            contadoDB.Nome = contato.Nome;
            contadoDB.Email = contato.Email;
            contadoDB.Celular = contato.Celular;
            
            _bancoContext.Update(contadoDB);
            _bancoContext.SaveChanges();

            return contadoDB;
        }
        public bool Deletar(int id)
        {
            Contato contadoDB = ListarPorId(id);

            if (contadoDB == null) throw new Exception("Houve um erro na exclusão do contato");

            _bancoContext.Contatos.Remove(contadoDB);
            _bancoContext.SaveChanges();
            return true;
        }
        public List<Contato> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public Contato ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
    }
}
