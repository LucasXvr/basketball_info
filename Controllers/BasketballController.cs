using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasketballInfo.Models;
using Microsoft.Extensions.Configuration;

namespace BasketballInfo.Controllers
{
    public interface IApiService
    {
        Task<List<Game>> GetNbaGamesAsync();
    }

    public class BasketballController : IApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public async Task<List<Game>> GetNbaGamesAsync()
        {
            try
            {
                var apiKey = _configuration["ApiSettings:BasketballApiKey"];
                _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

                HttpResponseMessage response = await _httpClient.GetAsync("https://api-basketball.p.rapidapi.com/games");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    // Processar a resposta e mapear para objetos C# (por exemplo, List<GameModel>)
                    // Retorne os dados processados
                    return new List<Game>(); // Substitua isso pelo processamento real
                }
                else
                {
                    // Lidar com erros, por exemplo, lançando uma exceção personalizada
                    throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Lidar com outras exceções, se necessário
                throw ex;
            }
        }
    }
}