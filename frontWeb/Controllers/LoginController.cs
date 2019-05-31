using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frontWeb.Models;
using System.Diagnostics;
using frontWeb.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace frontWeb.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet("/Login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string mail, string password)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";

            FormUrlEncodedContent formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
                { "mail", mail },
                { "password", password } 
            });

            using (var client = HttpClientHelper.GetHttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.GetCookies();

                //Sending request
                HttpResponseMessage Res = await client.PostAsync("auth/login", formContent);

                System.Diagnostics.Debug.WriteLine(Res);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    return Redirect("/User");
                }

                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
