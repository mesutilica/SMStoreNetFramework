using SMStore.Entities;
using SMStore.Service.Repositories;
using System.Web.Mvc;
using System.Web.Security;

namespace SMStoreNetFramework.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Repository<AppUser> repository = new Repository<AppUser>();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email, string password, string ReturnUrl)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                var kullanici = repository.Get(k => k.Email == email && k.Password == password && k.IsActive && k.IsAdmin);
                if (kullanici != null) // eğer kullanıcı varsa 
                {
                    Session["admin"] = kullanici; // bu şekilde kullanıcıyı bir session a atıp diğer sayfalarda erişebiliriz, giriş için bu zorunlu değil
                    FormsAuthentication.SetAuthCookie(kullanici.Username, true); // oturum aç
                    
                    return ReturnUrl == null ? Redirect("/Admin/") : Redirect(ReturnUrl);
                }
                else TempData["Mesaj"] = "<div class='alert alert-danger'>Giriş Başarısız!</div>";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("admin");
            FormsAuthentication.SignOut(); // çıkış yap
            return Redirect("/Admin/Login");
        }
    }
}