using Lil.Search.Interfaces;
using Lil.Search.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Product> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("productsServices");
            var response = await client.GetAsync($"api/products/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Product>(content);

            return product;

        }
    }
}
