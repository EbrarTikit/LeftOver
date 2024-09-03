using AutoMapper;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Interfaces.Repositories;

namespace CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants
{
    public class GetAllRestaurantsQuery : IRequest<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }


    }
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>>
    {
        private readonly IRestaurantRepositoryAsync _restaurantRepository;
        private readonly IMapper _mapper;
        public GetAllRestaurantsQueryHandler(
            IRestaurantRepositoryAsync restaurantRepository,
            IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllRestaurantsParameter>(request);
            var result = await _restaurantRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var viewModels = _mapper.Map<IEnumerable<GetAllRestaurantsViewModel>>(result);
            return new PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>(viewModels, validFilter.PageNumber, validFilter.PageSize); ;
        }
    }
}
