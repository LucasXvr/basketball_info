using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasketballInfo.Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BasketballInfo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BasketballController _basketballController;

        public HomeController(ILogger<HomeController> logger, BasketballController basketballController)
        {
            _logger = logger;
            _basketballController = basketballController;
        }

        public async Task<IActionResult> Index(DateTime? selectedDate)
        {
            var games = await _basketballController.GetNbaGames(selectedDate);

            return View(games);
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
