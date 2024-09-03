using CleanArchitecture.Core.Features.Restaurant.Command.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordResetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(new { message = "Your password has been reset successfully." });
            }

            return BadRequest(new { message = result.ErrorMessage });
        }
    }
}
