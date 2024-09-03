using CleanArchitecture.Core.Features.Favourites.Command.AddFavourite;
using CleanArchitecture.Core.Features.Favourites.Command.DeleteFavourite;
using CleanArchitecture.Core.Features.Favourites.Query.GetAllFavourites;
using CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FavouriteController : BaseApiController  
    {

        //POST /api/favourites
        [HttpPost]
        public async Task<IActionResult> Post(AddFavouriteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE /api/favourites/{id} 
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFavouriteCommand { Id = id }));
        }

        //GET /api/favourites/customer/{customer id}
        [HttpGet("customr/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>))]
        public async Task<PagedResponse<IEnumerable<GetAllRestaurantsViewModel>>> Get([FromQuery] GetAllRestaurantsParameter filter)
        {
            return await Mediator.Send(new GetAllRestaurantsQuery() { pageSize = filter.PageSize, pageNumber = filter.PageNumber });
        }

        [HttpGet("favorites/customer/{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllFavouriteViewModel>>))]
        public async Task<ActionResult<PagedResponse<IEnumerable<GetAllFavouriteViewModel>>>> GetAllFavorites(int customerId, [FromQuery] GetAllFavouriteParameter filter)
        {
            var favorites = await Mediator.Send(new GetAllFavouriteQuery { CustomerId = customerId, pageSize = filter.PageSize, pageNumber = filter.PageNumber });
            return Ok(favorites);
        }






    }
}
