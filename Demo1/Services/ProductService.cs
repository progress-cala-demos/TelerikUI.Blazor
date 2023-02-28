
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Demo1Shared.DTOs;

namespace Demo1.Services
{
    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetProducts(GridReadEventArgs args)
        {
            var request = await _http.PostAsJsonAsync("getproducts", args.Request);

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadFromJsonAsync<DataEnvelope<ProductDto>>();

                if (args.Request.Groups.Count > 0)
                {
                    args.Data = response.GroupedData.ToList();
                }
                else
                {
                    args.Data = response.CurrentPageData;
                }
                args.Total = response.TotalItemCount;
            }
        }

        public async Task CreateProduct(ProductDto product)
        {
            var response = await _http.PostAsJsonAsync("createproduct", product);
            if (response.IsSuccessStatusCode)
            {
            }

        }

        public async Task UpdateProduct(ProductDto product)
        {
            var response = await _http.PutAsJsonAsync("updateproduct", product);
            if (response.IsSuccessStatusCode)
            {
            }
        }
    }
}
