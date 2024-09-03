using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Item.Query.GetAllItem;
using CleanArchitecture.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IItemRepositoryAsync : IGenericRepositoryAsync<Item>
    {
        Task<ICollection<Item>> GetItemsByRestaurantIdAsync(int ýd);

        Task<IEnumerable<Item>> GetPagedResponseByRestaurantAsync(int restaurantId, int pageNumber, int pageSize);

    }
}