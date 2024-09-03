using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Interfaces.Repositories;

namespace CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName
{
    public class GetRestaurantsByNameQuery : IRequest<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>>
    {
        public string SearchString { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetPlaceByNameQueryHandler : IRequestHandler<GetRestaurantsByNameQuery, PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>>
    {
        private readonly IRestaurantRepositoryAsync _restaurantRepositoryAsync;

        public GetPlaceByNameQueryHandler(IRestaurantRepositoryAsync restaurantRepositoryAsync)
        {
            _restaurantRepositoryAsync = restaurantRepositoryAsync;
        }

        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> Handle(GetRestaurantsByNameQuery request, CancellationToken cancellationToken)
        {
            var validfilter = new GetRestaurantsByNameParameter
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                SearchString = request.SearchString
            };
            return (PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>) await _restaurantRepositoryAsync.GetRestaurantsByName(validfilter);
        }
    }    

}
