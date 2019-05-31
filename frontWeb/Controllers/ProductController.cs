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
            var model = new ProductsModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.GetAsync($"Product?offset={page}");

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.ProductList = JsonConvert.DeserializeObject<List<Product>>(response);

                }

                HttpResponseMessage Res2 = await client.GetAsync($"Category");

                if (Res2.IsSuccessStatusCode)
                {
                    var response = Res2.Content.ReadAsStringAsync().Result;
                    model.Categories = JsonConvert.DeserializeObject<List<Category>>(response);

                }
                return View("Index", model);
            }
        }

        [HttpGet("/Products/{IdCategory}")]
        public async Task<IActionResult> Category(long IdCategory)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            var model      = new ProductsModel();
            model.IdCategory = IdCategory;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.GetAsync($"Product/Category/{IdCategory}");

                if (Res.IsSuccessStatusCode)
                {  
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.ProductList = JsonConvert.DeserializeObject<List<Product>>(response);
                }

                HttpResponseMessage Res2 = await client.GetAsync($"Category");

                if (Res2.IsSuccessStatusCode)
                {
                    var response = Res2.Content.ReadAsStringAsync().Result; 
                    model.Categories = JsonConvert.DeserializeObject<List<Category>>(response);

                }
                return View("Index", model);
            }
        }


        [HttpGet("/Product/{id}")]
        public async Task<IActionResult> ProductDetail(long Id)
        {
            string Baseurl = "http://127.0.0.1:5000/api/";
            var model = new ProductDetailModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.GetAsync($"Product/{Id}");
                 
                if (Res.IsSuccessStatusCode)
                {  
                    var response = Res.Content.ReadAsStringAsync().Result;
                    model.Product = JsonConvert.DeserializeObject<Product>(response);
                }

                HttpResponseMessage Res2 = await client.GetAsync($"Product/Category/{model.Product.IdCategory}");

                if (Res2.IsSuccessStatusCode)
                { 
                    var response = Res2.Content.ReadAsStringAsync().Result;
                    model.RelatedProducts = JsonConvert.DeserializeObject<List<Product>>(response);
                }

                HttpResponseMessage Res3 = await client.GetAsync($"Category/{model.Product.IdCategory}");

                if (Res3.IsSuccessStatusCode)
                { 
                    var response = Res3.Content.ReadAsStringAsync().Result;
                    var category = JsonConvert.DeserializeObject<Category>(response);
                    model.CategoryName = category.Name;
                }
                
                return View("ProductDetail", model);
            }
        }

        [HttpPost("Products/Search")]
        public async Task<IActionResult> SearchProduct(string Search)
        {
            string Baseurl  = "http://127.0.0.1:5000/api/";
            var products    = new List<Product>();
            Search s        = new Search { Query = Search };
            var data        = new StringContent(JsonConvert.SerializeObject(s), System.Text.Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.PostAsync($"Product/Search", data);

                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    products = JsonConvert.DeserializeObject<List<Product>>(response);
                }

                return PartialView("_productList", products);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
