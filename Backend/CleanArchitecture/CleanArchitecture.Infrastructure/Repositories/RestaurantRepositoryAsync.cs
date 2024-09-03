using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RestaurantRepositoryAsync : GenericRepositoryAsync<Restaurant>, IRestaurantRepositoryAsync
    {

        private readonly DbSet<Restaurant> _restaurant;

        public RestaurantRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _restaurant = dbContext.Set<Restaurant>();
        }

        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> GetRestaurantsByName(GetRestaurantsByNameParameter parameter)
        {
            IQueryable<Restaurant> restaurants = _restaurant.AsQueryable();
            if (!string.IsNullOrEmpty(parameter.SearchString))
            {
                restaurants = restaurants.Where(f => f.Name.Contains(parameter.SearchString));
            }
            var totalRecords = await restaurants.CountAsync();
            if (totalRecords == 0)
            {
                throw new EntityNotFoundException("Restaurant", totalRecords);
            }
            restaurants = restaurants.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize);

            var result = await restaurants.Select(p => new GetAllRestaurantsViewModel
            {

                Name = p.Name,
                Email = p.Email,
                Password = p.Password,
                PhoneNumber = p.PhoneNumber,

                StreetInformation= p.StreetInformation,
                City = p.City,
                postalCode=p.postalCode,
                Country=p.Country,
                StoreType = p.StoreType,

              
            }).ToListAsync();
            return new PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Restaurant> GetByEmailAsync(string email)
        {
            return await _restaurant.FirstOrDefaultAsync(r => r.Email == email);
        }


       


    }
}
