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
        private readonly string BaseUrl = "https://localhost:44343/api/UserApi";
        public async Task<ActionResult> User()
        {
            var users = new List<User>();

            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(BaseUrl + "/GetAllUsers");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            var model = new User()
            {
                Name = "Alice",
                Surname = "Johnson",
                Age = 28,
                Email = "alice.johnson@example.com",
                Address = "789 Oak St, Springfield",
                Gender = Gender.Female
            };
            users.Add(model);
            users.Add(model);
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44343/");
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(BaseUrl + $"/UpdateUser/{user.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, errors = new List<string> { errorContent } });
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44343/"); 
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(BaseUrl + "/CreateUser", content);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, errors = new List<string> { errorContent } });
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
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors = errors });
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:44343/");

                var response = await httpClient.DeleteAsync($"api/UserApi/DeleteUser/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, errors = new List<string> { errorContent } });
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
    }
}