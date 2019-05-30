using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using frontWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace frontWeb.Controllers
{
    public class ProductController : Controller
    {
        public async Task<ActionResult> Index(int? page)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            List<Product> product = new List<Product>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request
                HttpResponseMessage Res = await client.GetAsync($"Product?offset={page}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    product = JsonConvert.DeserializeObject<List<Product>>(response);

                }
                //returning the employee list to view  
                return View(product);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
