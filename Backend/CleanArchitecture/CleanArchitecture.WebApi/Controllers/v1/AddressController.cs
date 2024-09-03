
using CleanArchitecture.Core.Features.Address.Command.DeleteAddress;
using CleanArchitecture.Core.Features.Address.Command.UpdateAddress;
using CleanArchitecture.Core.Features.Address.Query.GetAllAddresses;
using CleanArchitecture.Core.Features.Address.Command.CreateAddress;
using CleanArchitecture.Core.Features.Address.Query.GetAddressById;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.WebApi.Controllers;
/*using CleanArchitecture.Core.Features.Location.Command.CreateLocation;
using CleanArchitecture.Core.Features.Restaurant.Command.CreateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.DeleteRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Command.UpdateRestaurant;
using CleanArchitecture.Core.Features.Restaurant.Query.GetAllRestaurants;
using CleanArchitecture.Core.Features.Restaurant.Query.GetRestaurantById;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;*/

[ApiVersion("1.0")]
      public class AddressController : BaseApiController
      {
          [HttpPost]
          public async Task<IActionResult> Post(CreateAddressCommand command)
          {
              return Ok(await Mediator.Send(command));
          }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllAddressesViewModel>>))]
    public async Task<PagedResponse<IEnumerable<GetAllAddressesViewModel>>> Get([FromQuery] GetAllAddressesParameter filter, [FromQuery] string userName)
    {
        return await Mediator.Send(new GetAllAddressesQuery()
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber,
            UserName = userName
        });
    }


    [HttpDelete("{id}")]
          
          public async Task<IActionResult> Delete(int id)
          {
              return Ok(await Mediator.Send(new DeleteAddressCommand { Id = id }));
          }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateAddressCommand command)
          {
              if (id != command.Id)
              {
                  return BadRequest();
              }
              return Ok(await Mediator.Send(command));
          }

         
          [HttpGet("{id}")]

          public async Task<IActionResult> Get(int id)
          {
              return Ok(await Mediator.Send(new GetAddressByIdQuery { Id = id }));
          }

      }
