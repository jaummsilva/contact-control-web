using ContatosMVC.Filters;
using ContatosMVC.Models;
using ContatosMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ContatosMVC.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio
            , IContatoRepositorio contatoRepositorio,
            ITarefaRepositorio tarefaRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _contatoRepositorio= contatoRepositorio;
            _tarefaRepositorio = tarefaRepositorio;

        }
        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            var usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ListarContatosUsuariosId(int id)
        {
            List<Contato> contatos = _contatoRepositorio.BuscarTodos(id);
            return PartialView("_ContatosUsuario", contatos);
        }
        public IActionResult ListarTarefasUsuariosId(int id)
        {
            List<Tarefa> tarefas = _tarefaRepositorio.BuscarTodos(id);
            return PartialView("_TarefasUsuario", tarefas);
        }


        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            Usuario usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenha usuarioSemSenha)
        {
            try
            {
                Usuario? usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new Usuario()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Deletar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao excluir o usuario";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, tente novamente. Detalhe do erro : {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
