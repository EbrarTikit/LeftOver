using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Favourites.Query.GetAllFavourites;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class FavouritesRepositoryAsync : GenericRepositoryAsync<Favourites>, IFavouritesRepositoryAsync
    {

        private readonly DbSet<Favourites> _favourite;

        public FavouritesRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _favourite = dbContext.Set<Favourites>();
        }

        public async Task<PagedResponse<IEnumerable<GetAllFavouriteViewModel>>> GetAllFavorites(int customerId, int pageNumber, int pageSize)
        {
            IQueryable<Favourites> favorites = _favourite.Include(f => f.Restaurant).AsQueryable();

            // Query favorites based on customer ID
            favorites = favorites.Where(f => f.CustomerId == customerId);

            // Include the Restaurant entity
            favorites = favorites.Include(f => f.Restaurant);

            // Calculate total count before pagination
            var totalItems = await favorites.CountAsync();
            if (totalItems == 0)
            {
                throw new EntityNotFoundException("Favourites", totalItems);
            }

            // Apply pagination
            var pagedFavorites = await favorites.Skip((pageNumber - 1) * pageSize)
                                               .Take(pageSize)
                                               .ToListAsync();

            // Map the retrieved favorites to view models
            var favoriteViewModels = pagedFavorites.Select(f => new GetAllFavouriteViewModel
            {
                RestaurantId = f.RestaurantId,
                RestaurantName = f.Restaurant.Name, // Assuming Restaurant.Name is the property containing the restaurant name
                                                    // Map other properties as needed
            });

            // Create a paged response
            var pagedResponse = new PagedResponse<IEnumerable<GetAllFavouriteViewModel>>(favoriteViewModels, pageNumber, pageSize);

            return pagedResponse;
        }




    }
}
