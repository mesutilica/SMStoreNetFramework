using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Controllers
{
    public class NewsController : Controller
    {
        Repository<News> repositoryNews = new Repository<News>();
        // GET: News
        public ActionResult Index()
        {
            var model = repositoryNews.GetAll(n => n.IsActive);

            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = repositoryNews.Find(id);

            if(model is null) return HttpNotFound();

            return View(model);
        }
    }
}