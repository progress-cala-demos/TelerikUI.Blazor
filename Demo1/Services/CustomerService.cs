
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using static System.Net.WebRequestMethods;
using Demo1Shared.DTOs;

namespace Demo1.Services
{
    public class CustomerService
    {
        private readonly HttpClient _http;
        public TelerikGrid<CustomerDto> CustomerGrid { get; set; }
        public bool DialogVisible { get; set; }

        public CustomerService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetCustomers(GridReadEventArgs args)
        {
            var request = await _http.PostAsJsonAsync("getcustomers", args.Request);

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadFromJsonAsync<DataEnvelope<CustomerDto>>();

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

        public async Task<CustomerDto> CreateCustomer(CustomerDto customer)
        {
            var request = await _http.PostAsJsonAsync("createcustomer", customer);

            if (request.IsSuccessStatusCode)
            {
                CustomerGrid.Rebind();
                DialogVisible = false;
                return new();
            }

            return customer;
        }
    }
}
