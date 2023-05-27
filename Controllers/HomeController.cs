using DataTableToListConverter.Models;
using ListDataTableConverter.Extensions;
using ListDataTableConverter.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace DataTableToListConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //get data
            DataTable productData = new ProductData().GetData();

            //Datatable to list
            List<Product> products = productData.ToList<Product>();

            //List to Datatable 
            var pDataTable = products.ToDataTable();

            return View();
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