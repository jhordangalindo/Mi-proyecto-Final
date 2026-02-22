namespace WebAplicacion.DTOs
{
    public class RiskResultDto
    {
        public string Country { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public long Population { get; set; }
        public int EconomicScore { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
    }
}