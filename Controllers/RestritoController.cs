using ContatosMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
