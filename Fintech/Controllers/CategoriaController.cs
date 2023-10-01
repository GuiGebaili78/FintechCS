using Fintech.Controllers.Filters;
using Fintech.Models;
using Fintech.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepository categoriaRepository;

        public CategoriaController(DataBaseContext dataBaseContext)
        {
            categoriaRepository = new CategoriaRepository(dataBaseContext);
        }

        [LogFilter]
        public IActionResult Index()
        {
            var lista = categoriaRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new CategoriaModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Inserir(categoria);
                TempData["mensagem"] = "Categoria cadastrada com sucesso";
                return RedirectToAction("Index", "Categoria");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var categoria = categoriaRepository.Consultar(id);
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Alterar(categoria);
                TempData["mensagem"] = "Categoria alterada com sucesso";
                return RedirectToAction("Index", "Categoria");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Consultar(int id)
        {
            var categoria = categoriaRepository.Consultar(id);
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            categoriaRepository.Excluir(id);
            TempData["mensagem"] = "Categoria excluída com sucesso";
            return RedirectToAction("Index", "Categoria");
        }
    }
}
