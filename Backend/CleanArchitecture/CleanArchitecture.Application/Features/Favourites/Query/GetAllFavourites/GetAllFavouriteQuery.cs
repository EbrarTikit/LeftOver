using AutoMapper;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Filters;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Favourites.Query.GetAllFavourites
{
    public class GetAllFavouriteQuery : IRequest<PagedResponse<IEnumerable<GetAllFavouriteViewModel>>>
    {
        public int CustomerId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }

    public class GetAllFavouritesQueryHandler : IRequestHandler<GetAllFavouriteQuery, PagedResponse<IEnumerable<GetAllFavouriteViewModel>>>
    {

        private readonly IFavouritesRepositoryAsync _favouritesRepository;
        private readonly IMapper _mapper;

        public GetAllFavouritesQueryHandler(IFavouritesRepositoryAsync favouritesRepository, IMapper mapper)
        {
            _favouritesRepository = favouritesRepository;
            _mapper = mapper;
        }

        //distance?????
        public async Task<PagedResponse<IEnumerable<GetAllFavouriteViewModel>>> Handle(GetAllFavouriteQuery request, CancellationToken cancellationToken)
        {

            return await _favouritesRepository.GetAllFavorites(request.CustomerId, request.pageNumber, request.pageSize);
        }
    }
}