using Lil.Customers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Customers.DAL
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly List<Customer> _repo = new List<Customer>();

        public CustomersProvider()
        {
            _repo.Add(new Customer
            {
                Id = "1",
                Name = "Luis",
                City = "Medellín"
            });
            _repo.Add(new Customer
            {
                Id = "2",
                Name = "Rodrigo",
                City = "Ciudad de Mexico"
            });
            _repo.Add(new Customer
            {
                Id = "3",
                Name = "Renata",
                City = "Lima"
            });
            _repo.Add(new Customer
            {
                Id = "4",
                Name = "Raúl",
                City = "Madrid"
            });
        }

        public Task<Customer> GetAsync(string id)
        {
            var customer = _repo.FirstOrDefault(x => x.Id == id);

            return Task.FromResult(customer);
        }
    }
}
