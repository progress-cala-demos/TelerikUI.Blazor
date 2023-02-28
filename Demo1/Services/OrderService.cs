
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Demo1Shared.DTOs;

namespace Demo1.Services
{
    public class OrderService
    {
        private readonly HttpClient _http;
        public TelerikGrid<OrderDto> OrderGrid { get; set; }
        public List<OrderDto> Orders { get; set; }

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetOrders(GridReadEventArgs args)
        {
            var request = await _http.PostAsJsonAsync("getorders", args.Request);

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadFromJsonAsync<DataEnvelope<OrderDto>>();

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

        public async Task CreateOrder(OrderDto order)
        {
            var orderValidate = Orders.FirstOrDefault(o => o.CompanyName == order.CompanyName.Trim());
            if (orderValidate != null) 
            {
                order.CustomerId = orderValidate.CustomerId;
                var response = await _http.PostAsJsonAsync("createorder", order);
                if (response.IsSuccessStatusCode)
                {
                    Orders = new();
                }
                else
                {
                }
            }
        }

        public async Task UpdateOrder(OrderDto order)
        {
            OrderDto orderValidate = new();
            if (Orders.Count > 0)
            {
                orderValidate = Orders.FirstOrDefault(o => o.CompanyName == order.CompanyName.Trim());
                order.CustomerId = orderValidate != null ? orderValidate.CustomerId : string.Empty;
            }

            if (!string.IsNullOrEmpty(order.CustomerId))
            {
                var response = await _http.PutAsJsonAsync("updateorder", order);
                if (response.IsSuccessStatusCode)
                {
                    Orders = new();
                }
                else
                {
                }
            }
        }

        public async Task GetCustomersByCompanyName(AutoCompleteReadEventArgs args)
        {
            if (args.Request.Filters.Count > 0)
            {
                string name = ((FilterDescriptor)args.Request.Filters.First()).Value.ToString();
                var response = await _http.GetFromJsonAsync<List<OrderDto>>($"GetCustomersByCompanyName/{name}");

                args.Data = Orders = response;
            }
        }
    }
}
