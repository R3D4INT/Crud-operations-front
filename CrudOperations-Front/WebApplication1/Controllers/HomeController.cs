using System.Threading.Tasks;
using System.Web.Mvc;
using BackNewVersion;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Models.enums;


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
    }
}