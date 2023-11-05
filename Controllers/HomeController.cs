using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasketballInfo.Models;
using Microsoft.Extensions.Logging; // Adicione a diretiva necessária
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

        public async Task<IActionResult> Index()
        {
            if (_basketballController != null)
            {
                var games = await _basketballController.GetNbaGames();

                return View(games);
            }
            else
            {
                // Lide com o caso em que _basketballController é nulo
                return View("Error");
            }
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
