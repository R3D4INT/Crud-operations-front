using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.Models.Localization.CompositeViewsModels;
using WebApplication1.Models.Localization.User;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly LocalizationService _localizationService;
        public UserController()
        {
            _localizationService = new LocalizationService(CultureInfo.CurrentCulture);
        }

        [ValidateModelState]
        public async Task<ActionResult> User()
        {
            var users = new List<User>();
            var (isSuccess, content) = await SendHttpRequestAsync(ApiRoutes.GetAllUsers, HttpMethod.Get);

            if (isSuccess)
            {
                users = JsonConvert.DeserializeObject<List<User>>(content);
            }

            var localizationViewModel = _localizationService.GetLocalizedViewModel<UserViewModel>(ResourcePaths.UserResourcesPath,
                typeof(Front.Resources.Resources.User.User).Assembly);
            
            var model = new UserCompositeViewModel()
            {
                Users = users,
                UserViewModel = localizationViewModel
            };

            return View(model);
        }

        public async Task<ActionResult> Edit(User user)
        {
            var countries = await GetCountries();
            var (isSuccess, content) = await SendHttpRequestAsync($"{ApiRoutes.GetUser}{user.Id}", HttpMethod.Get);

            if (isSuccess)
            {
                user = JsonConvert.DeserializeObject<User>(content);
            }

            if (countries.Any())
            {
                ViewBag.CountriesSelectList = new SelectList(countries, "Name", "Name", user.Country.Name);
            }

            var localizationViewModel = _localizationService.GetLocalizedViewModel<EditViewModel>(ResourcePaths.EditResourcesPath,
                typeof(Front.Resources.Resources.User.Edit).Assembly);

            var model = new UserEditCompositeViewModel()
            {
                User = user,
                EditViewModel = localizationViewModel
            };

            return View(model);
        }

        [System.Web.Mvc.HttpPut]
        [ValidateModelState]
        public async Task<ActionResult> UpdateUser(User user)
        {
            user.Country = await GetCountryByName(user.Country.Name);
            var (isSuccess, content) = await SendHttpRequestAsync($"{ApiRoutes.UpdateUser}{user.Id}", HttpMethod.Put, user);

            if (isSuccess)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = new List<string> { content } });
        }

        public async Task<ActionResult> Add()
        {
            var countries = await GetCountries();

            if (countries.Any())
            {
                ViewBag.CountriesSelectList = new SelectList(countries, "Name", "Name");
            }

            var localizationViewModel = _localizationService.GetLocalizedViewModel<AddViewModel>(ResourcePaths.AddResourcesPath,
                typeof(Front.Resources.Resources.User.Add).Assembly);

            var model = new UserAddCompositeViewModel
            {
                User = new User(),
                AddViewModel = localizationViewModel
            };

            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateModelState]
        public async Task<ActionResult> AddUser(User user)
        {
            user.Country = await GetCountryByName(user.Country.Name);
            
            var (isSuccess, content) = await SendHttpRequestAsync(ApiRoutes.CreateUser, HttpMethod.Post, user);

            if (isSuccess)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = new List<string> { content } });
        }

        public async Task<ActionResult> Delete(User user)
        {
            var (isSuccess, content) = await SendHttpRequestAsync($"{ApiRoutes.GetUser}{user.Id}", HttpMethod.Get);

            if (isSuccess)
            {
                user = JsonConvert.DeserializeObject<User>(content);
            }

            var localizationViewModel = _localizationService.GetLocalizedViewModel<DeleteViewModel>(ResourcePaths.DeleteResourcesPath,
                typeof(Front.Resources.Resources.User.Delete).Assembly);

            var model = new UserDeleteCompositeViewModel()
            {
                User = user,
                DeleteViewModel = localizationViewModel
            };

            return View(model);
        }

        [System.Web.Mvc.HttpDelete]
        [ValidateModelState]
        public async Task<ActionResult> DeleteUser([FromBody] int id)
        {
            var (isSuccess, content) = await SendHttpRequestAsync($"{ApiRoutes.DeleteUser}{id}", HttpMethod.Delete);

            if (isSuccess)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = new List<string> { content } });
        }

        [ValidateModelState]
        public async Task<ActionResult> GetUser(int id)
        {
            var (isSuccess, content) = await SendHttpRequestAsync(ApiRoutes.GetUser, HttpMethod.Get);

            if (isSuccess)
            {
                var user = JsonConvert.DeserializeObject<User>(content);
                return Json(user);
            }

            return Json(new { success = false, errors = new List<string> { content } });
        }

        public async Task<List<Country>> GetCountries()
        {
            var (isSuccess, content) = await SendHttpRequestAsync(ApiRoutes.GetCountries, HttpMethod.Get);

            if (isSuccess)
            {
                var countries = JsonConvert.DeserializeObject<List<Country>>(content);
                return countries;
            }

            return new List<Country>();
        }

        private async Task<Country> GetCountryByName(string name)
        {
            var (isSuccess, content) = await SendHttpRequestAsync($"{ApiRoutes.GetCountry}{name}", HttpMethod.Get);

            if (isSuccess)
            {
                return JsonConvert.DeserializeObject<Country>(content);
            }

            return null;
        }
        private async Task<(bool isSuccess, string content)> SendHttpRequestAsync(string url, HttpMethod method, object data = null)
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(method, url);

                if (data != null)
                {
                    var json = JsonConvert.SerializeObject(data);
                    request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    return (true, content);
                }

                return (response.IsSuccessStatusCode, content);
            }
        }
    }
}   