using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        Repository<Category> repository = new Repository<Category>();
        // GET: Admin/Categories
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    category.Image = Image.FileName;
                }
                repository.Add(category);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category category, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    category.Image = Image.FileName;
                }
                repository.Update(category);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Categories/Delete/5
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
