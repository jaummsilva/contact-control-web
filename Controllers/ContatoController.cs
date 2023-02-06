using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
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


    }
}
