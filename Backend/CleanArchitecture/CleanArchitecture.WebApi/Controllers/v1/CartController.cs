using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Features.Cart.Command.CreateCart;
using CleanArchitecture.Core.Features.Cart.Command.DeleteCart;
using CleanArchitecture.Core.Features.Cart.Query.GetCardByCustomerId;
using CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    public class CartController : BaseApiController
    {

        //POST /api/cart
        [HttpPost]
        public async Task<IActionResult> Post(CreateCartCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE /api/cart/{id} 
        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCartCommand { Id = id }));
        }

        [HttpGet("cart/{customerId}")]
        public async Task<IActionResult> GetCartByCustomerId(int customerId)
        {
            var cart = await Mediator.Send(new GetCartByIdQuery { CustomerId = customerId });
            if (cart == null)
            {
                throw new ApiException($"Cart with defined CustomerId not found.");
            }
            return Ok(cart);
        }


    }
}
