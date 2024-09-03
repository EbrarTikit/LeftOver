using CleanArchitecture.Core.Entities;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface ICartRepositoryAsync : IGenericRepositoryAsync<Cart>
    {
        
        Task<Cart> GetCartByCustomerIdAsync(int customerId);
    }
}
