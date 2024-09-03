using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string StreetInformation { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers are allowed")]
        public string postalCode { get; set; }

        [Required] 
        public string Country { get; set; }

        [Required] 
        public string StoreType { get; set; }
        public string Picture { get; set; }
        //public LinkedList<Item> Items { get; set; }


    }

    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly IRestaurantRepositoryAsync _restaurantRepositoryAsync;



        public CreateRestaurantCommandHandler(
            IRestaurantRepositoryAsync restaurantRepositoryAsync)
        {
            _restaurantRepositoryAsync = restaurantRepositoryAsync;
        }


        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var newRestaurant = new Entities.Restaurant
            {
               
                Name = request.Name,
                Email= request.Email,
                Password=request.Password,
                PhoneNumber=request.PhoneNumber,
                StreetInformation=request.StreetInformation,
                City=request.City,
                postalCode=request.postalCode,
                Country=request.Country,
                StoreType=request.StoreType,
                Picture=request.Picture,
                
    };

            await _restaurantRepositoryAsync.AddAsync(newRestaurant);

            return newRestaurant.Id;
        }
    }
}