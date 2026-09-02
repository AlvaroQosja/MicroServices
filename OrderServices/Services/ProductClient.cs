using OrderServices.Models;

namespace OrderServices.Services;

public class ProductClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductClient> _logger;

    public ProductClient(HttpClient httpClient, ILogger<ProductClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Product> GetProduct(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/products/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<Product>();
                if (product != null)
                {
                    return product;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Product Service error for Product ID {Id}", id);
        }

        return new Product
        {
            Id = id,
            Name = "Unknown product",
            Price = 0m
        };
    }
}