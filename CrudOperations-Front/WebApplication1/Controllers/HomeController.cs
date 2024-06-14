using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = ViewHomeMessages.AboutMessage;

            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = ViewHomeMessages.ContactMessage;

            return View();
        }
        public ActionResult UserCrudOperations()
        {
            ViewBag.Message = ViewHomeMessages.UserCrudOperationsMessage;

            return Redirect(ViewHomeMessages.UserRedirectUrl);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            if (lang != "EN" && lang != "IT")
            {
                return RedirectToAction("Index");
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            var languageCookie = new HttpCookie("Language", lang);

            Response.Cookies.Add(languageCookie);

            return Redirect(Request.Headers["Referer"]);
        }
    }
}