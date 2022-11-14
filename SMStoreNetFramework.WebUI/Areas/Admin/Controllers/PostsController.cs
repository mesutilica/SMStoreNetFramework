using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        Repository<Post> repository = new Repository<Post>();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Posts/Create
        [HttpPost]
        public ActionResult Create(Post post, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    post.Image = Image.FileName;
                }
                repository.Add(post);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post post, HttpPostedFileBase Image)
        {
            try
            {
                if (Image != null)
                {
                    Image.SaveAs(Server.MapPath("/Images/" + Image.FileName));
                    post.Image = Image.FileName;
                }
                repository.Update(post);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = repository.Find(id);

            return View(model);
        }

        // POST: Admin/Posts/Delete/5
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
