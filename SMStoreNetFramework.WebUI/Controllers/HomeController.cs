using SMStore.Entities;
using SMStore.Service.Repositories;
using SMStoreNetFramework.WebUI.Models;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Controllers
{
    public class HomeController : Controller
    {
        Repository<Category> repositoryCategory = new Repository<Category>();
        Repository<Product> repositoryProduct = new Repository<Product>();
        Repository<News> repositoryNews = new Repository<News>();
        Repository<Slider> repositorySlider = new Repository<Slider>();
        public ActionResult Index()
        {
            var model = new HomePageViewModel()
            {
                News = repositoryNews.GetAll(n => n.IsActive),
                Products = repositoryProduct.GetAll(p => p.IsActive && p.IsHome),
                Sliders = repositorySlider.GetAll()
            };
            return View(model);
        }

        public ActionResult _PartialHeader()
        {
            return PartialView(repositoryCategory.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}