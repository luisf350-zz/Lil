using Lil.Search.Interfaces;
using Lil.Search.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lil.Search.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Customer> GetAsync(string id)
        {
            var client = _httpClientFactory.CreateClient("customersServices");
            var response = await client.GetAsync($"api/customers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var customer = JsonSerializer.Deserialize<Customer>(content);

            return customer;

        }
    }
}
