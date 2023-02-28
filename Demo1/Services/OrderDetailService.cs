
using System.Collections.Generic;
using System.Net.Http.Json;
using Demo1Shared.DTOs;
using Telerik.Blazor.Components;
using Telerik.DataSource;

namespace Demo1.Services
{
    public class OrderDetailService
    {
        private readonly HttpClient _http;
        public List<OrderDetailDto> OrderDetails { get; set; } = new();
        public TelerikGrid<OrderDto> OrderGrid { get; set; }

        public OrderDetailService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetOrderDetails(GridReadEventArgs args, int orderId)
        {
            var request = await _http.PostAsJsonAsync($"getorderdetails/{orderId}", args.Request);

            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadFromJsonAsync<DataEnvelope<OrderDetailDto>>();

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

        public async Task CreateOrderDetail(OrderDetailDto orderDetail, int orderId)
        {
            var orderDetailValidate = OrderDetails.FirstOrDefault(o => o.ProductName == orderDetail.ProductName.Trim());
            if (orderDetailValidate != null)
            {
                orderDetail.OrderId = orderId;
                orderDetail.ProductId = orderDetailValidate.ProductId;
                var response = await _http.PostAsJsonAsync("CreateOrderDetail", orderDetail);
                if (response.IsSuccessStatusCode)
                {
                    OrderDetails = new();
                }
            }
        }

        public async Task UpdateOrderDetail(OrderDetailDto orderDetail)
        {
            OrderDetailDto orderDetailValidate = new();
            if (OrderDetails.Count > 0)
            {
                orderDetailValidate = OrderDetails.FirstOrDefault(o => o.ProductName == orderDetail.ProductName.Trim());
                orderDetail.ProductId = orderDetailValidate != null ? orderDetailValidate.ProductId: string.Empty;
            }

            if (!string.IsNullOrEmpty(orderDetail.ProductId))
            {
                var response = await _http.PutAsJsonAsync("updateorderdetail", orderDetail);
                if (response.IsSuccessStatusCode)
                {
                    OrderDetails = new();
                }
            }
        }

        public async Task GetDetailsByProductName(AutoCompleteReadEventArgs args)
        {
            if (args.Request.Filters.Count > 0)
            {
                var response = await _http.PostAsJsonAsync($"GetDetailsByProductName", args.Request);

                if (response.IsSuccessStatusCode)
                {
                    OrderDetails = await response.Content.ReadFromJsonAsync<List<OrderDetailDto>>();
                    args.Data = OrderDetails;
                }
            }
        }
    }
}
