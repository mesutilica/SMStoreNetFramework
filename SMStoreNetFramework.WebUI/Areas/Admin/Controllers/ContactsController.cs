using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        Repository<Contact> repository = new Repository<Contact>();
        // GET: Admin/Contacts
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }

        // GET: Admin/Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                repository.Add(contact);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(contact);
        }

        // GET: Admin/Contacts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                repository.Update(contact);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(contact);
        }

        // GET: Admin/Contacts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var model = await repository.FindAsync(id);
                repository.Delete(model);
                await repository.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
