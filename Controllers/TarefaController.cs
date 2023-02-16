using ContatosMVC.Helpers;
using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ISessao _sessao;
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio, ISessao sessao)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _sessao = sessao;

        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            var tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            var tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }
        public IActionResult Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoUsuario();
            if (usuarioLogado.Perfil == Enums.PerfilEnum.Padrao)
            {
                List<Tarefa> tarefas = _tarefaRepositorio.BuscarTodos(usuarioLogado.Id);
                ViewData["Title"] = "Meus Contatos";
                return View(tarefas);
            }
            else
            {
                List<Tarefa> tarefasAdmin = _tarefaRepositorio.BuscarTodosAdmin().ToList();
                ViewData["Title"] = "Todas as tarefas";
                return View(tarefasAdmin);
            }
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tarefa = _tarefaRepositorio.Adicionar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa Cadastrada com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Index", tarefa);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua tarefa, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
