
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Demo1Shared.DTOs;

namespace Demo1.Services
{
    public class SaleService
    {
        private readonly HttpClient _http;
        public List<ChartSaleDto> ChartSales { get; set; } = new();

        public SaleService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetSalesByYear(int year)
        {
            ChartSales = await _http.GetFromJsonAsync<List<ChartSaleDto>>($"GetSalesByYear/{year}");
        }
    }
}
