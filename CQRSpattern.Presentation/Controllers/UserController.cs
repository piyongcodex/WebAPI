using Microsoft.AspNetCore.Mvc;
using CQRSpattern.Application.Users.Queries;
using MediatR;
using CQRSpattern.Application.Users.Commands.CreateUser;
using CQRSpattern.Application.Users.Commands.CreateUser.Enums;

namespace CQRSpattern.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid Id)
        {
            var command = new GetUserQuery(Id);

            return Ok(await _sender.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest dto)
        {
            var command = new CreateUserCommand(dto);
            var result = await _sender.Send(command);

            if (result.response == ResponseStatus.Conflict)
                return Conflict(new { title = "Conflict", message = "Username already exist" });

            return CreatedAtAction(nameof(GetUser), new { id = result.user.Id }, result.user);

        }
    }
}
