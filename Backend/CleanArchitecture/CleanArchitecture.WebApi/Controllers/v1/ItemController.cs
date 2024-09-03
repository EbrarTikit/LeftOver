using CleanArchitecture.Core.Features.Item.Command.CreateItem;
using CleanArchitecture.Core.Features.Item.Command.DeleteItem;
using CleanArchitecture.Core.Features.Item.Command.UpdateItem;
using CleanArchitecture.Core.Features.Item.Query.GetAllItem;
using CleanArchitecture.Core.Features.Item.Query.GetAllItemById;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ItemController : BaseApiController
    {
        //POST /api/item
        [HttpPost]
        public async Task<IActionResult> Post(CreateItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //GET /api/item
        [HttpGet]
        public async Task<IActionResult> GetAllItems([FromQuery] GetAllItemsQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        // DELETE /api/item/{id} 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteItemCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateItemCommand command)
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
            return Ok(await Mediator.Send(new GetItemByIdQuery { Id = id }));
        }
    }
}