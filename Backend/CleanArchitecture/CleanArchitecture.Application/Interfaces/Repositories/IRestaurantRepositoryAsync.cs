using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName;
using CleanArchitecture.Core.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IRestaurantRepositoryAsync : IGenericRepositoryAsync<Restaurant>
    {
        Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> GetRestaurantsByName(GetRestaurantsByNameParameter parameter);

        Task<Restaurant> GetByEmailAsync(string email);
        

    }
}
