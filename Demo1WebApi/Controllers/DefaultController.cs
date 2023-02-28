using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo1WebApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using Demo1Shared.DTOs;
using Demo1Shared.Utilitarios;
using System.Collections.Generic;

namespace Demo1WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly Demo1Context _db;

        public DefaultController(Demo1Context db)
        {
            _db = db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetOrders(DataSourceRequest request)
        {
            DataSourceResult result = await _db.Orders
                .Include(o => o.Customer)
                .OrderByDescending(o => o.OrderDate)
                .ToDataSourceResultAsync(request);

            var data = new DataEnvelope<OrderDto>();

            if (request.Groups.Count <= 0)
            {
                var orders = result.Data.OfType<Order>().ToList();
                var ordersDto = UtilitarioGeneral.MapearObjetos<Order,OrderDto>(orders, new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>().ForMember(
                                                                                        dest => dest.CompanyName,
                                                                                        opt => opt.MapFrom(src => src.Customer!.CompanyName))));
                data.CurrentPageData = ordersDto;
            }
            else
            {
                data.GroupedData = result.Data.Cast<AggregateFunctionsGroup>().ToList();
            }
            data.TotalItemCount = result.Total;

            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            var newOrder = UtilitarioGeneral.MapearObjetos<OrderDto,Order>(order);

            newOrder.OrderDate = DateTime.Now;
            try
            {
                await _db.Orders.AddAsync(newOrder);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrder(OrderDto order)
        {
            var updateOrder = UtilitarioGeneral.MapearObjetos<OrderDto, Order>(order);

            try
            {
                _db.Orders.Update(updateOrder);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetCustomersByCompanyName(string name)
        {
            List<OrderDto> ordersDto = await _db.Customers
                .Where(c => c.CompanyName.StartsWith(name))
                .Take(10)
                .Select(c => new OrderDto
                {
                    CustomerId = c.CustomerId,
                    CompanyName = c.CompanyName
                })
                .ToListAsync();
            return Ok(ordersDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetProducts(DataSourceRequest request)
        {
            DataSourceResult result = await _db.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.ProductId)
                .ToDataSourceResultAsync(request);

            var data = new DataEnvelope<ProductDto>();

            if (request.Groups.Count <= 0)
            {
                var products = result.Data.OfType<Product>().ToList();
                var productsDto = UtilitarioGeneral.MapearObjetos<Product, ProductDto>(products, new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDto>().
                                                                                                    ForMember(dest => dest.CategoryName,
                                                                                                                opt => opt.MapFrom(src => src.Category!.CategoryName))));

                data.CurrentPageData = productsDto;
            }
            else
            {
                data.GroupedData = result.Data.Cast<AggregateFunctionsGroup>().ToList();
            }
            data.TotalItemCount = result.Total;

            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct(ProductDto product)
        {
            var newProduct = UtilitarioGeneral.MapearObjetos<ProductDto, Product>(product);

            try
            {
                await _db.Products.AddAsync(newProduct);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct(ProductDto product)
        {
            var updateProduct = UtilitarioGeneral.MapearObjetos<ProductDto, Product>(product);

            try
            {
                _db.Products.Update(updateProduct);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            var categoriesDto = await _db.Categories.ProjectTo<CategoryDto>(new MapperConfiguration(cfg => cfg.CreateProjection<Category, CategoryDto>())).ToListAsync();
            return Ok(categoriesDto);
        }

        [HttpPost("[action]/{orderId}")]
        public async Task<IActionResult> GetOrderDetails(DataSourceRequest request, int orderId)
        {
            DataSourceResult result = await _db.OrderDetails
                .Where(o => o.OrderId == orderId)
                .Include(o => o.Product)
                .ToDataSourceResultAsync(request);

            var data = new DataEnvelope<OrderDetailDto>();

            if (request.Groups.Count <= 0)
            {
                var orderDetails = result.Data.OfType<OrderDetail>().ToList();
                var orderDetailsDto = UtilitarioGeneral.MapearObjetos<OrderDetail, OrderDetailDto>(orderDetails, new MapperConfiguration(cfg => cfg.CreateMap<OrderDetail, OrderDetailDto>()
                                                                                                                .ForMember(dest => dest.ProductName,
                                                                                                                           opt => opt.MapFrom(src => src.Product.ProductName))));

                data.CurrentPageData = orderDetailsDto;
            }
            else
            {
                data.GroupedData = result.Data.Cast<AggregateFunctionsGroup>().ToList();
            }
            data.TotalItemCount = result.Total;

            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailDto orderDetail)
        {
            var newOrderDetail = UtilitarioGeneral.MapearObjetos<OrderDetailDto, OrderDetail>(orderDetail);

            await _db.OrderDetails.AddAsync(newOrderDetail);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailDto orderDetail)
        {
            var updateOrderDetail = UtilitarioGeneral.MapearObjetos<OrderDetailDto, OrderDetail>(orderDetail);

            _db.OrderDetails.Update(updateOrderDetail);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetDetailsByProductName(DataSourceRequest request)
        {
            var result = await _db.Products.Where(p => !p.Discontinued).ToDataSourceResultAsync(request);
            var products  = result.Data.OfType<Product>().ToList();
            var orderDetailsDto = UtilitarioGeneral.MapearObjetos<Product, OrderDetailDto>(products);

            return Ok(orderDetailsDto);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetCustomers(DataSourceRequest request)
        {
            DataSourceResult result = await _db.Customers
                .OrderByDescending(c => c.CreationDate)
                .ToDataSourceResultAsync(request);

            var data = new DataEnvelope<CustomerDto>();

            if (request.Groups.Count <= 0)
            {
                var customers = result.Data.OfType<Customer>().ToList();
                var customersDto = UtilitarioGeneral.MapearObjetos<Customer, CustomerDto>(customers);

                data.CurrentPageData = customersDto;
            }
            else
            {
                data.GroupedData = result.Data.Cast<AggregateFunctionsGroup>().ToList();
            }
            data.TotalItemCount = result.Total;

            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCustomer(CustomerDto customer)
        {
            var newCustomer = UtilitarioGeneral.MapearObjetos<CustomerDto, Customer>(customer);

            do
            {
                Guid guid = Guid.NewGuid();
                for (int i = 0; i < 5; i++)
                {
                    string customerId = guid.ToString().ToUpper();
                    newCustomer.CustomerId += customerId[i];
                }
            } while (await _db.Customers.AnyAsync(c => c.CustomerId == newCustomer.CustomerId));

            newCustomer.CreationDate = DateTime.Now;
            await _db.Customers.AddAsync(newCustomer);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("[action]/{year}")]
        public async Task<IActionResult> GetSalesByYear(int year)
        {
            var salesByYear = await _db.SummaryOfSalesByYears.Where(s => s.ShippedDate!.Value.Year.Equals(year)).ToListAsync();
            var monthsOfSales = salesByYear.DistinctBy(s => s.ShippedDate!.Value.Month).Select(s => s.ShippedDate!.Value.Month).ToList();

            var ci = new CultureInfo("es-MX");
            TextInfo textInfo = ci.TextInfo;

            List<ChartSaleDto> chartSales = new List<ChartSaleDto>();

            foreach (var month in monthsOfSales)
            {
                var salesByMont = salesByYear.Where(s => s.ShippedDate!.Value.Month == month).ToList();
                chartSales.Add(new ChartSaleDto
                {
                    Month = textInfo.ToTitleCase(salesByMont.FirstOrDefault()!.ShippedDate!.Value.ToString("MMMM")),
                    TotalMonth = salesByMont.Sum(s => s.Subtotal)
                });
            }

            return Ok(chartSales);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CitiesByName(DataSourceRequest request)
        {
            var result = await _db.Cities.Select(c => c.CityName).ToDataSourceResultAsync(request);
            List<string> cities = result.Data.OfType<string>().ToList();

            return Ok(cities);
        }
    }
}