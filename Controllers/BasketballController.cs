using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BasketballInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace BasketballInfo.Controllers
{
    public class BasketballController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public BasketballController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public class ResponseData
        {
            public List<Game> Response { get; set; }
        }

        public async Task<List<Game>> GetNbaGames()
        {
            try
            {
                var apiKey = _configuration["ApiSettings:BasketballApiKey"];
                var league = "12";
                var season = "2023-2024";

                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new InvalidOperationException("Chave de API não encontrada. Verifique a configuração.");
                }

                _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

                var apiUrl = $"https://api-basketball.p.rapidapi.com/games?league={league}&season={season}";

                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    // Use o JsonSerializer para desserializar a resposta JSON em objetos C#
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var responseData = JsonSerializer.Deserialize<ResponseData>(content, options);

                    if (responseData != null && responseData.Response != null)
                    {
                        var validGames = responseData.Response
                            .Where(game =>
                                game.Scores?.Home?.Total != null &&
                                game.Scores.Away?.Total != null)
                            .ToList();

                        Console.WriteLine(validGames);
                        return validGames;
                    }
                    else
                    {
                        // Se não houver dados válidos ou valores nulos, retorna uma lista vazia
                        return new List<Game>();
                    }
                }
                else
                {
                    // Registre os detalhes da exceção
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    Console.WriteLine(await response.Content.ReadAsStringAsync());

                    // Lançar uma exceção personalizada ou retornar uma lista vazia
                    throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
                    return new List<Game>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
