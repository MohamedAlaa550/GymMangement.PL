using System.Diagnostics;
using GymMangement.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymMangement.PL.Controllers
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

       
    }
}
