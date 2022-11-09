using SMStore.Entities;
using SMStore.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class AppUsersController : Controller
    {
        Repository<AppUser> repository = new Repository<AppUser>();
        // GET: Admin/AppUsers
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/AppUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AppUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppUsers/Create
        [HttpPost]
        public ActionResult Create(AppUser appUser)
        {
            try
            {
                // TODO: Add insert logic here
                repository.Add(appUser);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(appUser);
        }

        // GET: Admin/AppUsers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/AppUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AppUser appUser)
        {
            try
            {
                // TODO: Add update logic here
                repository.Update(appUser);
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AppUsers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/AppUsers/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, AppUser appUser)
        {
            try
            {
                // TODO: Add delete logic here
                var model = await repository.FindAsync(id); // Ef Core da appUser entity si ile silme olurken burada gelen id ye göre kaydı bulup silinmek üzere Delete metoduna göndermemiz gerekiyor.
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
