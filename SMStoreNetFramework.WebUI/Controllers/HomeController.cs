using SMStore.Entities;
using SMStore.Service.Repositories;
using SMStoreNetFramework.WebUI.Models;
using SMStoreNetFramework.WebUI.Utils;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Controllers
{
    public class HomeController : Controller
    {
        Repository<Category> repositoryCategory = new Repository<Category>();
        Repository<Product> repositoryProduct = new Repository<Product>();
        Repository<News> repositoryNews = new Repository<News>();
        Repository<Slider> repositorySlider = new Repository<Slider>();
        Repository<Contact> repositoryContact = new Repository<Contact>();
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

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repositoryContact.Add(contact);
                    repositoryContact.SaveChanges();
                    TempData["Mesaj"] = @"<div class='alert alert-success'>Mesajınız Gönderildi! Teşekkürler..</div>";
                    bool sonuc = MailHelper.SendMail(contact);
                    if (sonuc)
                    {
                        // mail gönderme işlemi başarılıysa yapılacak işlemler
                    }
                    return RedirectToAction("ContactUs");
                }
                catch (System.Exception hata)
                {
                    // Todo:veritabanına hata loglanabilir
                    TempData["Mesaj"] = @"<div class='alert alert-danger'>Mesaj Gönderilemedi! Hata Oluştu!</div>";
                }
            }
            return View(contact);
        }
    }
}