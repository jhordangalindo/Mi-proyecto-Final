using WebAplicacion.Clients;
using WebAplicacion.DTOs;

namespace WebAplicacion.Services
{
    public class RiskAnalysisService
    {
        private readonly CountryClient _countryClient;
        private readonly IAClient _iaClient;

        public RiskAnalysisService(CountryClient countryClient, IAClient iaClient)
        {
            _countryClient = countryClient;
            _iaClient = iaClient;
        }

        public async Task<RiskResultDto> AnalyzeCountryRisk(string country)
        {
            var countryData = await _countryClient.GetCountryData(country);

            if (countryData == null)
            {
                return new RiskResultDto
                {
                    Country = country,
                    Region = "Desconocido",
                    Population = 0,
                    EconomicScore = 0,
                    RiskLevel = "Unknown",
                    Recommendation = "No se encontró información del país."
                };
            }

            int score = 50;

            if (countryData.Population > 50000000)
                score += 15;

            if (countryData.Region == "Europe")
                score += 20;

            if (countryData.Region == "Africa")
                score -= 10;

            string riskLevel = score >= 80 ? "Low"
                               : score >= 60 ? "Medium"
                               : "High";

            var recommendation =
                await _iaClient.GetRiskRecommendation(country, score);

            return new RiskResultDto
            {
                Country = countryData.Name,
                Population = countryData.Population,
                Region = countryData.Region,
                EconomicScore = score,
                RiskLevel = riskLevel,
                Recommendation = recommendation
            };
        }
    }
}