using System.Text.Json;
using gda_backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api", () =>
{
    return "Hello new api";
});

JsonSerializerOptions serializationOptions = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
};

string productsPath = "data/products.json";

app.MapGet("api/products", () =>
{
    var products = JsonSerializer.Deserialize<ProductsHub>(File.ReadAllText(productsPath), serializationOptions);

    return products;
});

app.Run();
