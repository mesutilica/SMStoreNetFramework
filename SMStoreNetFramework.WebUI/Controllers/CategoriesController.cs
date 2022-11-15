using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        Repository<Category> repository = new Repository<Category>();
        // GET: Categories
        public ActionResult Index(int id)
        {
            var model = repository.Find(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }
    }
}