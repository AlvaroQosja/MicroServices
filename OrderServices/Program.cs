using OrderServices.Data;
using OrderServices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<OrderStore>();

builder.Services.AddHttpClient<ProductClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5001/");
});

var app = builder.Build();

app.MapControllers();

app.Run();