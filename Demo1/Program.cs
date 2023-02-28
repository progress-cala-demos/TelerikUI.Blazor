using Demo1;
using Demo1.Common;
using Demo1.Services;
using Demo1.Resources;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Telerik.Blazor.Services;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7197/api/default/") });
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderDetailService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddTransient<GridConfig>();
builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(ResxLocalizer));

var host = builder.Build();

SetCulture(host);

await host.RunAsync();

static void SetCulture(WebAssemblyHost host)
{
    CultureInfo culture = new CultureInfo("es-MX");

    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}
