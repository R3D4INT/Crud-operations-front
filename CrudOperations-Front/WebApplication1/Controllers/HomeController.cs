using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models.Localization;
using WebApplication1.Models.Localization.Home;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly LocalizationService _localizationService;

        public HomeController()
        {
            _localizationService = new LocalizationService(CultureInfo.CurrentCulture);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var localizationViewModel = _localizationService.GetLocalizedViewModel<IndexViewModel>(ResourcePaths.IndexResourcesPath,
                typeof(Front.Resources.Resources.Home.Index).Assembly);

            return View(localizationViewModel);
        }

        public ActionResult About()
        {
            var localizationViewModel = _localizationService.GetLocalizedViewModel<AboutViewModel>(ResourcePaths.AboutResourcesPath,
                typeof(Front.Resources.Resources.Home.About).Assembly);

            return View(localizationViewModel);
        }

        public ActionResult Contact()
        {
            var localizationViewModel = _localizationService.GetLocalizedViewModel<ContactViewModel>(ResourcePaths.ContactResourcesPath,
                typeof(Front.Resources.Resources.Home.Contact).Assembly);

            return View(localizationViewModel);
        }

        public ActionResult UserCrudOperations()
        {
            return Redirect(Urls.UserRedirectUrl);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            if (lang != "EN" && lang != "IT")
            {
                return RedirectToAction("Index");
            }

            var cultureInfo = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            var languageCookie = new HttpCookie("Language", lang);
            Response.Cookies.Add(languageCookie);

            return Redirect(Request.Headers["Referer"]);
        }

    }
}