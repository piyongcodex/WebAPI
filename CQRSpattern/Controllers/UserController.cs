using CQRSpattern.Messenging.Commands;
using CQRSpattern.Messenging.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSpattern.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(GetUserQuery command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(GetUsersQuery command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
