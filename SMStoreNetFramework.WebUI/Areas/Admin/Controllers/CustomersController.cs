using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        Repository<Customer> repository = new Repository<Customer>();
        // GET: Admin/Customers
        public async Task<ActionResult> Index()
        {
            var model = await repository.GetAllAsync();
            return View(model);
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                repository.Add(customer);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                repository.Update(customer);
                repository.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await repository.FindAsync(id);
            return View(model);
        }

        // POST: Admin/Customers/Delete/5
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
