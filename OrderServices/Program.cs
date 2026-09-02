using OrderServices.Data;
using OrderServices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<OrderStore>();

builder.Services.AddHttpClient<ProductClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});

builder.Services.AddScoped<ProductIntegrationService>();

builder.Services.AddHttpClient("ProductService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5002/");
});

builder.Services.AddMemoryCache();

var app = builder.Build();

app.MapControllers();

app.Run();