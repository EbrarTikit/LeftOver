using CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Favourites.Command.AddFavourite
{
    public class AddFavouriteCommand : IRequest<int>
    {
        public int RestaurantId { get; set; }
        public int CustomerId { get; set; }

    }

    public class AddFavouriteCommandHandler : IRequestHandler<AddFavouriteCommand, int>
    {
        private readonly IFavouritesRepositoryAsync _favouriteRepositoryAsync;



        public AddFavouriteCommandHandler(
            IFavouritesRepositoryAsync favouriteRepositoryAsync)
        {
            _favouriteRepositoryAsync = favouriteRepositoryAsync;
        }


        public async Task<int> Handle(AddFavouriteCommand request, CancellationToken cancellationToken)
        {
            var newFavourite = new Entities.Favourites
            {

                CustomerId = request.CustomerId,
                RestaurantId = request.RestaurantId

            };

            await _favouriteRepositoryAsync.AddAsync(newFavourite);

            return newFavourite.Id;
        }
    }
}
