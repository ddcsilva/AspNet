using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.Contexts;
using Web.Models;

namespace Web.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Novo(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = context.Fabricantes.Find(id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Fabricante fabricante)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fabricante).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(fabricante);
        }

        public ActionResult Consultar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = context.Fabricantes.Find(id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fabricante fabricante = context.Fabricantes.Find(id);

            if (fabricante == null)
            {
                return HttpNotFound();
            }

            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            TempData["Mensagem"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";

            return RedirectToAction("Index");
        }
    }
}