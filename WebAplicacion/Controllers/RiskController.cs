using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Services;
using WebAplicacion.DTOs;

namespace WebAplicacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiskController : ControllerBase
    {
        private readonly RiskAnalysisService _riskService;

        public RiskController(RiskAnalysisService riskService)
        {
            _riskService = riskService;
        }

        [HttpGet("{country}")]
        public async Task<ActionResult<RiskResultDto>> GetRisk(string country)
        {
            if (string.IsNullOrWhiteSpace(country))
                return BadRequest("Debe proporcionar un país válido.");

            var result = await _riskService.AnalyzeCountryRisk(country);

            if (result == null)
                return NotFound("País no encontrado.");

            return Ok(result);
        }
    }
}