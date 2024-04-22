using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TermianlMVCApp.ViewModels;
using TermianlMVCApp.Services;

namespace TermianlMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VendistaApiService _apiService;

        public HomeController(VendistaApiService apiService,ILogger<HomeController> logger)
        {
            _logger = logger;
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _apiService.GetCommandsTypes();
            var myView = new MyViewModel { CommandTypes = data };
            return View("MyView", myView);
        }

        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpPost]
        [Route("/terminals/{id}/commands")]
        public IActionResult PostCommand(int id, [Bind("Title,ReleaseDate,Genre,Price")] CommandViewModel command)
        {
            int commandId = command.CommandId;
            // Выполните необходимые действия на сервере, используя переданные данные commandId и id

            // Верните соответствующий результат (например, сообщение об успехе или код состояния HTTP)

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
