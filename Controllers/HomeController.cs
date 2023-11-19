using MedControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedControl.Controllers
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
            return View();
        }

        public IActionResult Privacidade()
        {
            return View();
        }

        [Route("/Home/Error")]
        public IActionResult Error(int? statusCode)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View("NotFound");
            }

            return View("Error");
        }
    }
}