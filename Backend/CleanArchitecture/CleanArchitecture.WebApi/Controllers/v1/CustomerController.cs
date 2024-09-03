using CleanArchitecture.Core.Features.Customer.Command.UpdateCustomer;
using CleanArchitecture.Core.Features.Restaurant.Command.UpdateRestaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CustomerController : BaseApiController
    {

        // PUT /api/customer/{id}
        [HttpPut("customer/update/{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

    }
}
