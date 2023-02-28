using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using static System.Net.WebRequestMethods;

namespace Demo1.Services
{
    public class CityService
    {
        private readonly HttpClient _http;

        public CityService(HttpClient http)
        {
            _http = http;
        }

        public async Task CitiesByName(AutoCompleteReadEventArgs args)
        {
            if (args.Request.Filters.Count > 0)
            {
                var request = await _http.PostAsJsonAsync("CitiesByName", args.Request);
                var response = await request.Content.ReadFromJsonAsync<List<string>>();

                args.Data = response;
            }
        }
    }
}
