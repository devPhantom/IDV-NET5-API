using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using frontWeb.Models;
using frontWeb.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace frontWeb.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet("/Products")]
        public async Task<ActionResult> Index(int? page)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            //List<Product> product = new List<Product>();
            var model = new ProductsModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Sending request
                HttpResponseMessage Res = await client.GetAsync($"Product?offset={page}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    model.ProductList = JsonConvert.DeserializeObject<List<Product>>(response);

                }

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
                return View("Index", model);
            }
        }

        [HttpGet("/Products/Category/{id}")]
        public async Task<IActionResult> Category(long Id)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            var model      = new ProductsModel();
            model.IdCategory = Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Sending request
                HttpResponseMessage Res = await client.GetAsync($"Product/Category/{Id}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    model.ProductList = JsonConvert.DeserializeObject<List<Product>>(response);

                }

                HttpResponseMessage Res2 = await client.GetAsync($"Category");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res2.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var response = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from api and storing into the Product list  
                    model.Categories = JsonConvert.DeserializeObject<List<Category>>(response);

                }
                return View("Index", model);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
