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
using CleanArchitecture.Core.Entities;


namespace CleanArchitecture.Core.Features.Restaurant.Command.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IRequest<Response<int>>
    {
     public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetInformation { get; set; }
        public string City { get; set; }
        public string postalCode { get; set; }
        public string Country { get; set; }
        public string StoreType { get; set; }
        public string Picture { get; set; }

        public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, Response<int>>
        {
            private readonly IRestaurantRepositoryAsync _restaurantRepository;
            public UpdateRestaurantCommandHandler(IRestaurantRepositoryAsync restaurantRepository)
            {
                _restaurantRepository = restaurantRepository;
            }
            public async Task<Response<int>> Handle(UpdateRestaurantCommand command, CancellationToken cancellationToken)
            {
                var restaurant = await _restaurantRepository.GetByIdAsync(command.Id);

                if (restaurant == null) throw new EntityNotFoundException("restaurant", command.Id);

                restaurant.Name = command.Name;
                restaurant.Email = command.Email;
                restaurant.Password = command.Password;
                restaurant.PhoneNumber = command.PhoneNumber;
                restaurant.City = command.City;
                restaurant.postalCode = command.postalCode;
                restaurant.Country = command.Country;
                restaurant.StreetInformation = command.StreetInformation;
                restaurant.StoreType = command.StoreType;
                restaurant.Picture = command.Picture;

                await _restaurantRepository.UpdateAsync(restaurant);

                return new Response<int>(restaurant.Id);
            }
        }
    }
}
