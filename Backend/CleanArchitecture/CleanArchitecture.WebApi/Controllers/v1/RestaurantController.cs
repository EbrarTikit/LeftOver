using CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.ResetPassword;
using CleanArchitecture.Core.Features.Restaurant.Command.SignInRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.UpdateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantById;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantsByName;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class RestaurantController : BaseApiController
    {


        private readonly IRestaurantRepositoryAsync _restaurantRepository;

        public RestaurantController(IRestaurantRepositoryAsync restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        //POST /api/restaurant
        [HttpPost]
        public async Task<IActionResult> Post(CreateRestaurantCommand command)
        {
            return Ok(await Mediator.Send(command));
        }



        // POST /api/restaurant/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRestaurantCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.Success)
            {
                // If success, create session
                HttpContext.Session.SetString("RestaurantEmail", command.Email);
                return Ok(await Mediator.Send(command));

            }

            return Unauthorized(new { message = result.ErrorMessage });
        }

        // GET /api/restaurant/profile
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var email = HttpContext.Session.GetString("RestaurantEmail");
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(new { message = "Not signed in." });
            }

            var restaurant = _restaurantRepository.GetByEmailAsync(email).Result;
            return Ok(restaurant);
        }




        //GET /api/restaurant
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> Get([FromQuery] GetAllRestaurantsParameter filter)
        {
            return await Mediator.Send(new GetAllRestaurantsQuery() { pageSize = filter.PageSize, pageNumber = filter.PageNumber });
        }

        // DELETE /api/restaurant/{id} 
        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteRestaurantCommand { Id = id }));
        }

        // PUT /api/restaurant/{id}
        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateRestaurantCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // GET /api/restaurant/{id}
        [HttpGet("getby/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRestaurantByIdQuery { Id = id }));
        }

        // GET /api/restaurant/{name}
        [HttpGet("{name}")]
        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> Get([FromQuery] GetRestaurantsByNameParameter filter)
        {
            return await Mediator.Send(new GetRestaurantsByNameQuery() { SearchString= filter.SearchString,PageSize=filter.PageSize, PageNumber = filter.PageNumber });
        }

       

            [HttpPost("reset-password")]
            public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
            {
                var result = await Mediator.Send(command);
                if (result.Success)
                {
                    return Ok(new { message = "Your password has been reset successfully." });
                }

                return BadRequest(new { message = result.ErrorMessage });
            }
        }
    
}

