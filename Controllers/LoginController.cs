using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
           
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Entrar(Login loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Usuario usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.LoginEntrar);
                    if (usuario != null)
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index","Home");
                        }   
                        TempData["MensagemErro"] = "Senha inválida. Tente novamente";

                    }
                    TempData["MensagemErro"] = "Usuario e/ou senha inválido(s). Tente novamente";
                }
                return View("Home","Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
