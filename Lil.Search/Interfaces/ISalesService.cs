using Lil.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lil.Search.Interfaces
{
    public interface ISalesService
    {
        Task<ICollection<Order>> GetAsync(string customerId);
    }
}
