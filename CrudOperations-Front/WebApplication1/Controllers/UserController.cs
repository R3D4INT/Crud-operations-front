using System;
using BackNewVersionModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.enums;
using User = WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly string BaseUrl = "https://localhost:7110/api/UserApi";
        public async Task<ActionResult> User()
        {
            var validationResult = CheckModelState();
            if (validationResult != null)
            {
                return validationResult;
            }
            var users = new List<User>();
            var (isSuccess, content) = await SendHttpRequestAsync(BaseUrl + "/GetAllUsers", HttpMethod.Get);
            if (isSuccess)
            {
                users = JsonConvert.DeserializeObject<List<User>>(content);
            }

            return View(users);
        }
        public ActionResult Edit(User user)
        {
            ViewBag.Message = "Page for edit user";
            return View(user);
        }
        [System.Web.Mvc.HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            var validationResult = CheckModelState();
            if (validationResult != null)
            {
                return validationResult;
            }

            using (var httpClient = new HttpClient())
            {
                var (isSuccess, content) = await SendHttpRequestAsync(BaseUrl + $"/UpdateUser/{user.Id}", HttpMethod.Put, user);
                if (isSuccess)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = new List<string> { content } });
            }
        }
        public ActionResult Add()
        {
            ViewBag.Message = "Page for add the user";
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            var validationResult = CheckModelState();
            if (validationResult != null)
            {
                return validationResult;
            }

            using (var httpClient = new HttpClient())
            {
                var (isSuccess, content) = await SendHttpRequestAsync(BaseUrl + "/CreateUser", HttpMethod.Post, user);
                if (isSuccess)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = new List<string> { content } });
            }
        }
        public ActionResult Delete(User user)
        {
            ViewBag.Message = "Page for delete the user";
            return View(user);
        }

        [System.Web.Mvc.HttpDelete]
        public async Task<ActionResult> DeleteUser([FromBody] int id)
        {
            var validationResult = CheckModelState();
            if (validationResult != null)
            {
                return validationResult;
            }

            using (var httpClient = new HttpClient())
            {
                var (isSuccess, content) = await SendHttpRequestAsync(BaseUrl + $"/DeleteUser/{id}", HttpMethod.Delete);
                if (isSuccess)
                {
                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = new List<string> { content } });
            }
        }
        public async Task<ActionResult> GetUser(int id)
        {
            var user = new User();
            using (var httpClient = new HttpClient())
            {
                
                var response = await httpClient.GetAsync(BaseUrl + "/GetUser");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(content);
                }
            }

            return Json(user);
        }
        private async Task<(bool isSuccess, string content)> SendHttpRequestAsync(string url, HttpMethod method, object data = null)
        {
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(method, url);

                if (data != null)
                {
                    var json = JsonConvert.SerializeObject(data);
                    request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                return (response.IsSuccessStatusCode, content);
            }
        }
        private JsonResult CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }
            return null;
        }
    }
}