using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using frontWeb.Models;
using frontWeb.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace frontWeb.Controllers
{
    public class UserController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            User user = new User();

            using (var client = HttpClientHelper.GetHttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //Sending request
                HttpResponseMessage Res = await client.GetAsync("user/me");

                System.Diagnostics.Debug.WriteLine("ICI");

                System.Diagnostics.Debug.WriteLine(Res);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    user = JsonConvert.DeserializeObject<User>(response);

                    return View(user);
                }

                return Redirect("/Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
