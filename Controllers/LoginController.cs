using ContatosMVC.Helpers;
using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        

        public LoginController(IUsuarioRepositorio usuarioRepositorio,ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;

        }
           
        public IActionResult Index()
        {
            // se o usuario estiver logado redirecionar para a Home //

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
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
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index","Home");
                        }   

                        TempData["MensagemErro"] = "Senha inválida. Tente novamente";

                    }
                    TempData["MensagemErro"] = "Usuario e/ou senha inválido(s). Tente novamente";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
