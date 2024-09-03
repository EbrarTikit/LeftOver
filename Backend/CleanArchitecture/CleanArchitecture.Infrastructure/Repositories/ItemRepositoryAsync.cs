using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Favourites.Query.GetAllFavourites;
using CleanArchitecture.Core.Features.Item.Query.GetAllItem;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ItemRepositoryAsync : GenericRepositoryAsync<Item>, IItemRepositoryAsync
    {

        private readonly DbSet<Item> _item;

        public ItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _item = dbContext.Set<Item>();
        }

        public async Task<IEnumerable<Item>> GetPagedResponseByRestaurantAsync(int restaurantId, int pageNumber, int pageSize)
        {
            return await _item
                                   .Where(item => item.RestaurantId == restaurantId)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();
        }
        public async Task<ICollection<Item>> GetItemsByRestaurantIdAsync(int restaurantId)
        {
            return await _item.Where(i => i.RestaurantId == restaurantId).ToListAsync();
        }

    }
}