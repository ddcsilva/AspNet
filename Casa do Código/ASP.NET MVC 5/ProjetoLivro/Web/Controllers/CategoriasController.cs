using System.Collections.Generic;
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
            return View();
        }
    }
}