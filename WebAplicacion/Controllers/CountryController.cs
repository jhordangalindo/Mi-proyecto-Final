using Microsoft.AspNetCore.Mvc;
using WebAplicacion.Clients;
using WebAplicacion.DTOs;

namespace WebAplicacion.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly CountryClient _countryClient;

        public CountryController(CountryClient countryClient)
        {
            _countryClient = countryClient;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCountry(string name)
        {
            try
            {
                var country = await _countryClient.GetCountryData(name);
                return Ok(country);
            }
            catch
            {
                return NotFound("Country not found");
            }
        }
    }
}
