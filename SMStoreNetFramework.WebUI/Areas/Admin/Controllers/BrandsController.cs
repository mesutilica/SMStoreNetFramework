using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        Repository<Brand> repository = new Repository<Brand>();
        // GET: Admin/Brands
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Brands/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        [HttpPost]
        public ActionResult Create(Brand brand, HttpPostedFileBase Image) // .net frameworkde resimleri HttpPostedFileBase nesnesi ile yakalıyoruz.
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    brand.Image = Image.FileName;
                }
                repository.Add(brand);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(brand);
        }

        // GET: Admin/Brands/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Brands/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Brand brand, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    brand.Image = Image.FileName;
                }
                repository.Update(brand);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(brand);
        }

        // GET: Admin/Brands/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Brands/Delete/5
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
