using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BasketballInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

public class TeamsController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public TeamsController(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<List<Teams>> GetTeams()
    {
        try
        {
            var apiKey = _configuration["ApiSettings:BasketballApiKey"];

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("Chave de API não encontrada. Verifique a configuração.");
            }

            _httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", apiKey);

            var apiUrl = $"https://free-nba.p.rapidapi.com/teams";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                // Use o JsonSerializer para desserializar a resposta JSON em objetos C#
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Para corresponder ao estilo do JSON
                };

                var responseData = JsonSerializer.Deserialize<TeamsRoot>(content, options);

                if (responseData != null)
                {
                    return responseData.data;
                }
                else
                {
                    // Se não houver dados válidos ou valores nulos, retorna uma lista vazia
                    Console.WriteLine("Os dados ou a lista de times estão nulos.");
                    return new List<Teams>();
                }
            }
            else
            {
                // Registra os detalhes da exceção
                Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                Console.WriteLine(await response.Content.ReadAsStringAsync());

                // Lançar uma exceção personalizada ou retornar uma lista vazia
                throw new HttpRequestException($"Erro na requisição: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exceção capturada: " + ex);
            throw ex;
        }
    }
}