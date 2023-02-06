using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
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
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult DeletarConfirmacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }


    }
}
