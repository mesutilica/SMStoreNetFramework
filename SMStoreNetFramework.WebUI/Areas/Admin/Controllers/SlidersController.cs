using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class SlidersController : Controller
    {
        Repository<Slider> repository = new Repository<Slider>();
        // GET: Admin/Sliders
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Sliders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        [HttpPost]
        public ActionResult Create(Slider slider, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    slider.Image = Image.FileName;
                }
                repository.Add(slider);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }

        // POST: Admin/Sliders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Slider slider, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    slider.Image = Image.FileName;
                }
                repository.Update(slider);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);
            return View(model);
        }

        // POST: Admin/Sliders/Delete/5
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
