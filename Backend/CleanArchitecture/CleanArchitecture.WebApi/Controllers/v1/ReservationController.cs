using CleanArchitecture.Core.Features.Reservation.Commands.DeleteReservation;
using CleanArchitecture.Core.Features.Reservation.Commands.CreateReservationCommand;
using CleanArchitecture.Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Core.Features.Reservation.Commands;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ReservationController : BaseApiController
    {

        //POST /api/favourites
        [HttpPost]
        public async Task<IActionResult> Post(CreateReservation command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE /api/favourites/{id} 
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteReservation { Id = id }));
        }

        






    }
}
