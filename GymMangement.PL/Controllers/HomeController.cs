using System.Diagnostics;
using GymMangement.BLL.Services.IntrerFaces;
using GymMangement.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymMangement.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnalyticsService _analyticsService;

        public HomeController(ILogger<HomeController> logger,
            IAnalyticsService analyticsService)
        {
            _logger = logger;
            _analyticsService = analyticsService;
        }

        public IActionResult Index()
        {
            var analyticsData = _analyticsService.GetAnalyticsData();
            return View(analyticsData);
        }

       
    }
}
