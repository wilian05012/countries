using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

using countries.api.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Api.Controllers {
    [ApiController]
    public class CountriesController : ControllerBase {
        private readonly IDataService _dataService;
        public CountriesController(IDataService dataService) {
            _dataService = dataService;
        }

        /// <summary>
        ///     Get all countries
        /// </summary>
        /// <response code="200">Returns all countries</response>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpGet("all", Name = nameof(GetAllCountriesAsync))]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountriesAsync() => Ok(await _dataService.GetAllCountriesAsync());

        /// <summary>
        ///     Get country by code
        /// </summary>
        /// <param name="codes">CCA2 or CCA3 code. (single value)</param>
        /// <response code="200">Returns found country</response>
        /// <response code="404">Country not found</response>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpGet("alpha", Name = nameof(GetCountryByCodeAsync))]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCountryByCodeAsync([FromQuery] string codes) {
            var country = await _dataService.GetCountryByCodeAsync(codes);
            if (country is null) {
                return NotFound($"Country with code {codes} not found.");
            }
            return Ok(country);
        }


        /// <summary>
        ///   Search country by name
        /// </summary>
        /// <param name="name">Search by name</param>
        /// <response code="200">Returns found countries</response>
        [HttpGet("name/{name}", Name = nameof(SearchCountryByNameAsync))]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchCountryByNameAsync(string name) => Ok(await _dataService.SearchCountryByNameAsync(name));
    }
}
