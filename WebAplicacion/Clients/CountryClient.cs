using System.Text.Json;
using WebAplicacion.DTOs;

namespace WebAplicacion.Clients
{
    public class CountryClient
    {
        private readonly HttpClient _httpClient;

        public CountryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CountryDto?> GetCountryData(string country)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                   $"https://restcountries.com/v3.1/name/{country}"
                );

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();

                using var document = JsonDocument.Parse(json);

                if (document.RootElement.GetArrayLength() == 0)
                    return null;

                var root = document.RootElement[0];

                return new CountryDto
                {
                    Name = root.GetProperty("name").GetProperty("common").GetString() ?? "",
                    Region = root.GetProperty("region").GetString() ?? "",
                    Population = root.GetProperty("population").GetInt64()
                };
            }
            catch
            {
                return null;
            }
        }
    }
}