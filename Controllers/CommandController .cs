using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermianlMVCApp.Data;
using TermianlMVCApp.Services;
using TermianlMVCApp.ViewModels;

namespace TermianlMVCApp.Controllers
{
    /*public class CommandController : Controller
    {
        private readonly string apiBaseUrl;
        private readonly string apiToken;
        private readonly VendistaApiService _apiService;
        private readonly ICommandService _service;

        public CommandController(VendistaApiService apiService, ICommandService service)
        {
            apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            apiToken = ConfigurationManager.AppSettings["ApiToken"];
            _apiService = apiService;
            _service = service;
        }

        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                string response = await _apiService.GetApiResponseAsync("endpoint");

                var commands = new List<SelectListItem>
                {
                    new SelectListItem { Value = "1", Text = "Команда 1" },
                    new SelectListItem { Value = "2", Text = "Команда 2" },
                    // Добавьте остальные команды
                };

                ViewBag.Commands = commands;
                ViewBag.Parameter1Name = "parameter_name1";
                ViewBag.Parameter1DefaultValue = "parameter_default_value1";
                // Аналогично для остальных параметров

                var sentCommands = _service.GetAllCommands;

                return View(sentCommands);
            }
            catch (Exception ex)
            {
                // Обработка ошибки
                return View("Error", ex.Message);
            }            
        }

        [HttpPost]
        public ActionResult SendCommand([FromBody] int terminalId, int commandId, string parameter1, string parameter2, string parameter3)
        {
            var commandModel = new CommandViewModel
            {
                TerminalId = terminalId,
                CommandId = commandId,
                Parameter1 = parameter1,
                Parameter2 = parameter2,
                Parameter3 = parameter3
            };

            // Отправка команды через Web API
            // Используйте HttpClient или другую библиотеку для выполнения HTTP-запросов

            var sentCommand = new SentCommandModel
            {
                DateTimeSent = DateTime.Now,
                Command = commandModel.CommandId.ToString(),
                Parameter1 = commandModel.Parameter1,
                Parameter2 = commandModel.Parameter2,
                Parameter3 = commandModel.Parameter3,
                Status = "отправка в процессе"
            };

            dbContext.SentCommands.Add(sentCommand);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }*/
}
