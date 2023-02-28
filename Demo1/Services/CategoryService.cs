using System.Net.Http.Json;
using Demo1Shared.DTOs;
using Telerik.Blazor.Components;

namespace Demo1.Services
{
    public class CategoryService
    {
        private readonly HttpClient _http;
        public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetCategories()
        {
            var request = await _http.GetAsync("getcategories");

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
                Categories = response;
            }
        }

    }
}
