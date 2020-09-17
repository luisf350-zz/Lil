using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Lil.Search.Interfaces;
using Lil.Search.Models;

namespace Lil.Search.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order>> GetAsync(string customerId)
        {
            var client = _httpClientFactory.CreateClient("salesServices");
            var response = await client.GetAsync($"api/sales/{customerId}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var orders = JsonSerializer.Deserialize<ICollection<Order>>(content);

            return orders;
        }
    }
}
