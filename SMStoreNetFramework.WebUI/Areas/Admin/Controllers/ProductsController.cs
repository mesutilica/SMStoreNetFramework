using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        Repository<Product> repository = new Repository<Product>();
        Repository<Brand> repositoryBrand = new Repository<Brand>();
        Repository<Category> repositoryCategory = new Repository<Category>();
        // GET: Admin/Products
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(repositoryBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(repositoryCategory.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    product.Image = Image.FileName;
                }
                repository.Add(product);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.BrandId = new SelectList(repositoryBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(repositoryCategory.GetAll(), "Id", "Name");
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);
            ViewBag.BrandId = new SelectList(repositoryBrand.GetAll(), "Id", "Name", model.BrandId);
            ViewBag.CategoryId = new SelectList(repositoryCategory.GetAll(), "Id", "Name", model.CategoryId);
            return View(model);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    product.Image = Image.FileName;
                }
                repository.Update(product);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            ViewBag.BrandId = new SelectList(repositoryBrand.GetAll(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(repositoryCategory.GetAll(), "Id", "Name");
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Products/Delete/5
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
