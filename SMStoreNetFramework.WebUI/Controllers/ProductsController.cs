using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        Repository<Product> repository = new Repository<Product>();
        // GET: Products
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = repository.Find(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }
        public ActionResult Search(string search)
        {
            var model = repository.GetAll(p=>p.Name.Contains(search));

            return View(model);
        }
    }
}