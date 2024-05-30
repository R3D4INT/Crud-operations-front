using System.Threading.Tasks;
using System.Web.Mvc;
using BackNewVersion;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserCrudOperations()
        {
            ViewBag.Message = "Page for crud operations with user";

            return Redirect($"https://localhost:44374/User/User");
        }
    }
}