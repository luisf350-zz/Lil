using Lil.Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Products.DAL
{
    public class ProductsProvider : IProductsProvider
    {

        private readonly List<Product> _repo = new List<Product>();

        public ProductsProvider()
        {
            for (int i = 0; i <= 100; i++)
            {
                _repo.Add(new Product
                {
                    Id = (i+1).ToString(),
                    Name = $"Producto {i + 1}",
                    Price = i * 3.14

                });
            }
        }

        public Task<Product> GetAsync(string id)
        {
            var product = _repo.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(product);
        }
    }
}
