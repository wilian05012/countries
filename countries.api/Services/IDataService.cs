using System;
using System.Text.Json;

namespace countries.api.Services;

public interface IDataService {
    Task<JsonDocument> GetAllCountriesAsync();
    Task<JsonElement?> GetCountryByCodeAsync(string code);
    Task<IEnumerable<JsonElement>> SearchCountryByNameAsync(string name);
}
