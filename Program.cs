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

app.MapGet("api/products", async () =>
{
    FileStream fileStream = File.OpenRead(productsPath);
    var products = await JsonSerializer.DeserializeAsync<ProductsHub>(fileStream, serializationOptions);

    return products;
});

string selectedProductsPath = "data/selectedproducts.json";

app.MapGet("api/user/selections", async () => {

    if (!File.Exists(selectedProductsPath))
    {
        return [];
    }

    FileStream fileStream = File.OpenRead(selectedProductsPath);

    var selections = await JsonSerializer.DeserializeAsync<string[]>(fileStream, serializationOptions);

    return selections;
});

app.MapPost("", async (string[] selections) => {
    
    await File.WriteAllTextAsync(selectedProductsPath, JsonSerializer.Serialize(selections));
    return Results.Ok();
});

app.Run();
