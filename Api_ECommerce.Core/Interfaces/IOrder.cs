using System.Collections.Generic;
using System.Threading.Tasks;
using Api_ECommerce.Core.Entities;

namespace Api_ECommerce.Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
    }
}
