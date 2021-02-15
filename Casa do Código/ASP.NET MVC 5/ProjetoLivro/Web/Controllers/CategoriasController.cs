using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Contexts;
using Web.Models;

namespace Web.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c => c.Nome));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        public ActionResult Consultar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria categoria = context.Categorias.Find(id);

            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            TempData["Mensagem"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";

            return RedirectToAction("Index");
        }
    }
}