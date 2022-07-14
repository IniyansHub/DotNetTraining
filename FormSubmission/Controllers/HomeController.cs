using FormSubmission.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        List<Adhaar> adhaarList = new List<Adhaar>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        [Route("showdata")]
        public IActionResult? DisplayData(Adhaar adhaar)
        {
            adhaarList.Add(adhaar);
            return View(adhaarList);
           
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