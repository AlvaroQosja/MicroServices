using Microsoft.Extensions.Caching.Memory;
using OrderServices.Models;

namespace OrderServices.Services;

public class ProductIntegrationService
{
    private readonly ProductClient _productClient;
    private readonly IMemoryCache _cache;

    public ProductIntegrationService(ProductClient productClient, IMemoryCache cache)
    {
        _productClient = productClient;
        _cache = cache;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        string cacheKey = $"product_{productId}";

        if (_cache.TryGetValue(cacheKey, out Product? cachedProduct) && cachedProduct != null)
        {
            return cachedProduct;
        }

        var product = await _productClient.GetProduct(productId);

        var cacheOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
            .SetSize(1);

        _cache.Set(cacheKey, product, cacheOptions);

        return product;
    }
}