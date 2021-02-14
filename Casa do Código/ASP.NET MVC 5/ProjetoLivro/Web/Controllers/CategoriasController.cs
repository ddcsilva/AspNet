using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class CategoriasController : Controller
    {
        private static readonly IList<Categoria> categorias = new List<Categoria>()
            {
                new Categoria() { Id = 1, Nome = "Notebooks" },
                new Categoria() { Id = 2, Nome = "Monitores" },
                new Categoria() { Id = 3, Nome = "Impressoras" },
                new Categoria() { Id = 4, Nome = "Mouses" },
                new Categoria() { Id = 5, Nome = "Desktops" }
            };

        public ActionResult Index()
        {
            return View(categorias);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Categoria categoria)
        {
            categoria.Id = categorias.Select(c => c.Id).Max() + 1;
            categorias.Add(categoria);

            return RedirectToAction("Index");
        }

        public ActionResult Editar(long id)
        {
            return View(categorias.Where(m => m.Id == id).First());
        }
    }
}