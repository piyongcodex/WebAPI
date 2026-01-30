using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
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
        public async Task<IActionResult> GetUser(GetUserCommand command)
        {
            return Ok(await _sender.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(GetUsersCommand command)
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
