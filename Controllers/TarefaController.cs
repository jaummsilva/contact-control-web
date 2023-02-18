using ContatosMVC.Data;
using ContatosMVC.Filters;
using ContatosMVC.Helpers;
using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContatosMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class TarefaController : Controller
    {
        private readonly ISessao _sessao;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly BancoContext _bancoContext;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio, ISessao sessao, BancoContext bancoContext, IUsuarioRepositorio usuarioRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _sessao = sessao;
            _bancoContext = bancoContext;
            _usuarioRepositorio= usuarioRepositorio;

        }
        [PaginaRestritaAdmin]
        public IActionResult Criar()
        {
            return View();
        }
        [PaginaRestritaAdmin]
        public IActionResult Editar(int id)
        {
            var tarefa = _tarefaRepositorio.ListarPorId(id);
            return View(tarefa);
        }
        [PaginaRestritaAdmin]
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
                ViewData["Title"] = "Minhas tarefas";
                return View(tarefas);
            }
            else
            {
                List<Tarefa> tarefasAdmin = _tarefaRepositorio.BuscarTodosAdmin().ToList();
                ViewData["Title"] = "Todas as tarefas";
                return View(tarefasAdmin);
            }
        }
        [PaginaRestritaAdmin]

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
        [PaginaRestritaAdmin]
        [HttpPost]
        public IActionResult Alterar(Tarefa tarefa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Atualizar(tarefa);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Index", tarefa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar essa tarefa, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [PaginaRestritaAdmin]
        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _tarefaRepositorio.Deletar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa excluida com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao excluir a tarefa";
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguir remover essa tarefa, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
