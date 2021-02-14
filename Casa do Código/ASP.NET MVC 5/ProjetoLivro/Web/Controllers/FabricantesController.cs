using System.Linq;
using System.Web.Mvc;
using Web.Contexts;

namespace Web.Controllers
{
    public class FabricantesController : Controller
    {
        private EFContext context = new EFContext();

        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c => c.Nome));
        }
    }
}