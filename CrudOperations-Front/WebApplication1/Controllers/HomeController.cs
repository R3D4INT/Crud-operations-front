using System.Threading.Tasks;
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
    }
}