using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using TermianlMVCApp.ViewModels;

namespace TermianlMVCApp.Services
{
    public class VendistaApiService
    {
        private readonly HttpClient _httpClient;
        private string _token;

        public VendistaApiService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration.GetSection("ApiSettings:ApiUrl").Value)!;
            string login = configuration.GetSection("ApiSettings:Username").Value!;
            string password = configuration.GetSection("ApiSettings:Password").Value!;

            // Выполняем запрос на авторизацию и получаем токен
            GetToken(login, password).GetAwaiter().GetResult();
        }
        private async Task GetToken(string login, string password)
        {
            var requestUri = $"{_httpClient.BaseAddress.ToString()}token?login={login}&password={password}";
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var tokenObject = JObject.Parse(json);
                _token = tokenObject["token"].ToString();
            }
        }

        public async Task<List<CommandType>> GetCommandsTypes()
        {
            var requestUri =$"{_httpClient.BaseAddress.ToString()}commands/types" + $"?token={_token}";
            var response = await _httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(json);
                var items = jsonObject["items"].ToString();
                var commandTypes = JsonConvert.DeserializeObject<List<CommandType>>(items);
                return commandTypes;
            }
            return null;
        }
    }
}