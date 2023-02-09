using ContatosMVC.Filters;
using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;

        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            var contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        
        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Deletar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao excluir o contato";
                }
                return RedirectToAction("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
