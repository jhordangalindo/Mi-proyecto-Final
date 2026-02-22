using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WebAplicacion.Clients
{
    public class IAClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public IAClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetRiskRecommendation(string country, int score)
        {
            var apiKey = _configuration["OpenRouter:ApiKey"];
            var model = _configuration["OpenRouter:Model"];

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            _httpClient.DefaultRequestHeaders.Add("HTTP-Referer", "http://localhost");
            _httpClient.DefaultRequestHeaders.Add("X-Title", "WebAplicacion");

            var requestBody = new
            {
                model = model,
                messages = new[]
                {
                    new { role = "system", content = "Eres un analista financiero experto en inversiones internacionales." },
                    new { role = "user", content = $"Analiza si es viable invertir en {country} con un score económico de {score}/100. Indica claramente si es recomendable invertir o no y explica brevemente." }
                },
                temperature = 0.7,
                max_tokens = 300
            };

            var content = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://openrouter.ai/api/v1/chat/completions",
                content
            ); 

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return $"Error IA: {response.StatusCode} - {error}";
            }

            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);

            var result = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return result ?? "No se pudo generar recomendación.";
        }
    }
}