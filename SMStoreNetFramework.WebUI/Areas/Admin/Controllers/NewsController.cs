using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        Repository<News> repository = new Repository<News>();
        // GET: Admin/News
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        [HttpPost]
        public ActionResult Create(News news, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    news.Image = Image.FileName;
                }
                repository.Add(news);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, News news, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    news.Image = Image.FileName;
                }
                repository.Update(news);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var model = repository.Find(id);
                repository.Delete(model);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
