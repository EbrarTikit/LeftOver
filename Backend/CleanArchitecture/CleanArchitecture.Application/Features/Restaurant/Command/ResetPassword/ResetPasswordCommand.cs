using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CleanArchitecture.Core.Features.Restaurant.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest<ResetPasswordResult>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }

    public class ResetPasswordResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResult>
    {
        private readonly IRestaurantRepositoryAsync _restaurantRepository;

        public ResetPasswordCommandHandler(IRestaurantRepositoryAsync restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ResetPasswordResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            // Check if the new password and confirmation match
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    ErrorMessage = "The new password and confirmation do not match."
                };
            }

            // Get the restaurant by email
            var restaurant = await _restaurantRepository.GetByEmailAsync(request.Email);
            if (restaurant == null)
            {
                return new ResetPasswordResult
                {
                    Success = false,
                    ErrorMessage = "Email not found."
                };
            }

            // Update the restaurant's password
            restaurant.Password = request.NewPassword;
            await _restaurantRepository.UpdateAsync(restaurant);

            return new ResetPasswordResult
            {
                Success = true
            };
        }
    }
}
