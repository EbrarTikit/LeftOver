using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Favourites.Query.GetAllFavourites;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName;
using CleanArchitecture.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IFavouritesRepositoryAsync : IGenericRepositoryAsync<Favourites>
    {
        Task<PagedResponse<IEnumerable<GetAllFavouriteViewModel>>> GetAllFavorites(int customerID, int pageNumber, int pageSize);


    }
}
