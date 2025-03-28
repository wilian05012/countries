using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace countries.api.Services;

public class DataService : IDataService {
    private const string DATA_FILENAME = "countries.api.Data.countries.json";

    private static Task<JsonDocument> GetDatAsync() {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = DATA_FILENAME;

        using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? throw new InvalidOperationException($"Resource '{resourceName}' not found.")) {
                return JsonDocument.ParseAsync(stream);
        }
    }

    public Task<JsonDocument> GetAllCountriesAsync() => GetDatAsync();

    public async Task<JsonElement?> GetCountryByCodeAsync (string code) {
        var doc = await GetDatAsync();
        var root = doc.RootElement;
        var countries = root.EnumerateArray();
        foreach (var country in countries) {
            var countryFound = (new string[] {
                "cca2", "cca3"
            })
                .Select(propName => country.GetProperty(propName).GetString()?.Trim())
                .Any(propValue => propValue?.Equals(code, StringComparison.OrdinalIgnoreCase) == true);  
            if (countryFound) {
                return country.Clone();
            }
        }
        return null;
    }

    public async Task<IEnumerable<JsonElement>> SearchCountryByNameAsync(string name) {
        var doc = await GetDatAsync();
        var root = doc.RootElement;
        var countries = root.EnumerateArray();
        var result = new List<JsonElement>();
        foreach (var country in countries) {
            var countryName = country.GetProperty("name").GetProperty("common").GetString();
            if (countryName?.Contains(name, StringComparison.OrdinalIgnoreCase) == true) {
                result.Add(country.Clone());
            }
        }
        return result;
    }

}
