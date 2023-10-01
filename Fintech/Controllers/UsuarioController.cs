using Fintech.Controllers.Filters;
using Fintech.Models;
using Fintech.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepository usuarioRepository;

        public UsuarioController(DataBaseContext dataBaseContext)
        {
            usuarioRepository = new UsuarioRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            var lista = usuarioRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new UsuarioModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Inserir(usuario);
                TempData["mensagem"] = "Usuário cadastrado com sucesso";
                return RedirectToAction("Index", "Usuario");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Alterar(usuario);
                TempData["mensagem"] = "Usuário alterado com sucesso";
                return RedirectToAction("Index", "Usuario");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var usuario = usuarioRepository.Consultar(id);
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {

            usuarioRepository.Excluir(id);
            TempData["mensagem"] = "Usuário excluído com sucesso";
            return RedirectToAction("Index", "Usuario");
        }
    }
}
