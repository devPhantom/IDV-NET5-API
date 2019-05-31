using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frontWeb.Models;
using System.Net.Http;
using Newtonsoft.Json;
using frontWeb.Models.ViewModel;

namespace frontWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/Home")]
        public async Task<IActionResult> Index(int? page)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            var model = new HomeModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res2 = await client.GetAsync($"Category");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    model.Categories = JsonConvert.DeserializeObject<List<Category>>(response);

                }
                //returning the employee list to view  
                return View(model);
            }
        }

        [HttpGet("/Home/Details")]
        public IActionResult Details()
        {
            return View("Detail");
        }

        [HttpGet("/Card")]
        public IActionResult Card()
        {
            return View("Card");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
