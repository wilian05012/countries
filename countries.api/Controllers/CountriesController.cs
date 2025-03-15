using System.Reflection;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Api.Controllers {
    [Route("all")]
    [ApiController]
    public class CountriesController : ControllerBase {
        /// <summary>
        ///     Get all countries
        /// </summary>
        /// <response code="200">Returns all countries</response>
        /// <exception cref="InvalidOperationException"></exception>
        [HttpGet(Name = "GetAllCountries")]
        [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCountries() {
            string data = @"countries.api.Data.countries.json";

            using (var dataReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(data) ?? throw new InvalidOperationException("Resource not found"))) {
                var countries = await dataReader.ReadToEndAsync();
                System.Text.Json.JsonDocument json = System.Text.Json.JsonDocument.Parse(countries);
                return Ok(json);
            }
        }
    }
}
