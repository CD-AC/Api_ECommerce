using System.Collections.Generic;
using System.Threading.Tasks;
using Api_ECommerce.Core.Entities;

namespace Api_ECommerce.Core.Interfaces
{
    public interface IClient
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}
