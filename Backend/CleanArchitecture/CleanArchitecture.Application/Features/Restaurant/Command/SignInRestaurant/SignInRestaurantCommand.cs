using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Restaurant.Command.SignInRestaurant
{
    public class SignInRestaurantCommand : IRequest<SignInResult>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int Id   {get; set; }
}

    public class SignInRestaurantCommandHandler : IRequestHandler<SignInRestaurantCommand, SignInResult>
    {
        private readonly IRestaurantRepositoryAsync _restaurantRepository;

        public SignInRestaurantCommandHandler(IRestaurantRepositoryAsync restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<SignInResult> Handle(SignInRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantRepository.GetByEmailAsync(request.Email);
            if (restaurant == null || restaurant.Password != request.Password)
            {
                return new SignInResult
                {
                    Success = false,
                    ErrorMessage = "Invalid email or password."
                };
            }

            return new SignInResult
            {
                Success = true,
                Id = restaurant.Id
            };
        }
    }
}
