using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CleanArchitecture.Core.Interfaces.Repositories;

namespace CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, Response<int>>
        {
            private readonly IRestaurantRepositoryAsync _restaurantRepository;
            public DeleteRestaurantCommandHandler(IRestaurantRepositoryAsync restaurantRepository)
            {
                _restaurantRepository = restaurantRepository;
            }
            public async Task<Response<int>> Handle(DeleteRestaurantCommand command, CancellationToken cancellationToken)
            {
                var restaurant = await _restaurantRepository.GetByIdAsync(command.Id);
                if (restaurant == null) throw new ApiException($"Restaurant Not Found.");
                await _restaurantRepository.DeleteAsync(restaurant);
                return new Response<int>(restaurant.Id);
            }
        }
    }
}