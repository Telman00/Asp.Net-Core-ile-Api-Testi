using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspClientApp.Models;

namespace aspClientApp.Controllers;

public class HomeController : Controller
{

    public async Task<IActionResult> Index()
    {
var products = new List<ProductDTO>();
using(var httpClient = new HttpClient())
{
   using(var response =  httpClient.GetAsync("http://localhost:5014/api/products"))
   {
    string apiResponse = await response.Content.ReadAsStringAsync();
    products = JsonSerializer.Deserialize<List<ProductDTO>>(apiResponse);
   }
}

        return View();
    }

}
