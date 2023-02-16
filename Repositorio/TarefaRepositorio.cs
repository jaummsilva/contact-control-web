using ContatosMVC.Data;
using ContatosMVC.Models;

namespace ContatosMVC.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public TarefaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Tarefa Adicionar(Tarefa tarefa)
        {
           _bancoContext.Tarefas.Add(tarefa);
            _bancoContext.SaveChanges();
            return tarefa;
        }

        public Tarefa Atualizar(Tarefa tarefa)
        {
            Tarefa tarefaDB = ListarPorId(tarefa.Id);
            
            if (tarefaDB == null) throw new Exception("Houve um erro na atualização do contato");
            
            tarefaDB.descricao = tarefa.descricao;
            tarefaDB.TarefaEnum = tarefa.TarefaEnum;
            tarefaDB.DataFinal = tarefa.DataFinal;
            
            _bancoContext.Update(tarefaDB);
            _bancoContext.SaveChanges();

            return tarefaDB;
        }
        public bool Deletar(int id)
        {
            Tarefa tarefaDB = ListarPorId(id);

            if (tarefaDB == null) throw new Exception("Houve um erro na exclusão do contato");

            _bancoContext.Tarefas.Remove(tarefaDB);
            _bancoContext.SaveChanges();
            return true;
        }
        public List<Tarefa> BuscarTodos(int usuarioId)
        {
            return _bancoContext.Tarefas.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public Tarefa ListarPorId(int id)
        {
            return _bancoContext.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public List<Tarefa> BuscarTodosAdmin()
        {
            return _bancoContext.Tarefas.ToList();
        }
    }
}
