using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.Sales.Models;

namespace Lil.Sales.DAL
{
    public class SalesProvider : ISalesProvider
    {
        private readonly List<Order> _repo = new List<Order>();

        public SalesProvider()
        {
            _repo.Add(new Order
            {
                Id = "0001",
                CustomerId = "1",
                OrderDate = DateTime.Now.AddMonths(-1),
                Total = 250,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        OrderId = "0001",
                        Price = 50,
                        ProductId = "23",
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        Id = 2,
                        OrderId = "0001",
                        Price = 50,
                        ProductId = "11",
                        Quantity = 3
                    }
                }
            });
            _repo.Add(new Order
            {
                Id = "0002",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-2),
                Total = 100,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        OrderId = "0002",
                        Price = 50,
                        ProductId = "55",
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        Id = 2,
                        OrderId = "0002",
                        Price = 50,
                        ProductId = "77",
                        Quantity = 3
                    }
                }
            });
            _repo.Add(new Order
            {
                Id = "0003",
                CustomerId = "2",
                OrderDate = DateTime.Now.AddMonths(-3),
                Total = 100,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        OrderId = "0003",
                        Price = 50,
                        ProductId = "55",
                        Quantity = 2
                    },
                    new OrderItem
                    {
                        Id = 2,
                        OrderId = "0003",
                        Price = 50,
                        ProductId = "77",
                        Quantity = 3
                    }
                }
            });
            _repo.Add(new Order
            {
                Id = "0004",
                CustomerId = "3",
                OrderDate = DateTime.Now.AddDays(-10),
                Total = 50,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        Id = 1,
                        OrderId = "0004",
                        Price = 50,
                        ProductId = "55",
                        Quantity = 1
                    }
                }
            });
        }

        public Task<ICollection<Order>> GetAsync(string customerId)
        {
            var orders = _repo.Where(x => x.CustomerId == customerId).ToList();

            return Task.FromResult((ICollection<Order>)orders);
        }
    }
}
