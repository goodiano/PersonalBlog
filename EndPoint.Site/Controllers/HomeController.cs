using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModel.HomePages;
using GoodianoBlog.Application.Services.Common.GetHomePagePosts;
using GoodianoBlog.Application.Services.HomePage.Query.GetSliders;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetHomePageImageServices _getHomePage;
        private readonly IGetSliderServices _getSlider;

        public HomeController(ILogger<HomeController> logger , IGetHomePageImageServices getHomePage , IGetSliderServices getSlider)
        {
            _logger = logger;
            _getHomePage = getHomePage;
            _getSlider = getSlider;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                GetHomePageImages = _getHomePage.Execute().Data,
                GetSliders = _getSlider.Execute().Data,
            };
            return View(homePage);
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