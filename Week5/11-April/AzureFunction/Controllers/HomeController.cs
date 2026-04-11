using AzureFunction.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AzureFunction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory; //added
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Index(SalesRequest salesRequest)
        {
            salesRequest.Id = Guid.NewGuid().ToString();
            using var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://azurefunc20260411100158-feb8d5etdufbfpc9.centralindia-01.azurewebsites.net/api/");
            using (var content = new StringContent(JsonConvert.SerializeObject(salesRequest), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage response = await client.PostAsync("OnSalesUploadWriteToQueue", content);
                string returnValue = await response.Content.ReadAsStringAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
