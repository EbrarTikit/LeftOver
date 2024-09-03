using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Favourites.Command.DeleteFavourite
{
    public class DeleteFavouriteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFavouriteCommandHandler : IRequestHandler<DeleteFavouriteCommand, Response<int>>
        {
            private readonly IFavouritesRepositoryAsync _favouriteRepository;
            public DeleteFavouriteCommandHandler(IFavouritesRepositoryAsync favouriteRepository)
            {
                _favouriteRepository = favouriteRepository;
            }
            public async Task<Response<int>> Handle(DeleteFavouriteCommand command, CancellationToken cancellationToken)
            {
                var favourite = await _favouriteRepository.GetByIdAsync(command.Id);
                if (favourite == null) throw new ApiException($"Favourite Not Found.");
                await _favouriteRepository.DeleteAsync(favourite);
                return new Response<int>(favourite.Id);
            }
        }
    }
}
