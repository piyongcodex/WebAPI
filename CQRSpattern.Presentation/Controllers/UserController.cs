using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.Commands.CreateUser;
using CQRSpattern.Application.Users.Commands.DeleteUser;
using CQRSpattern.Application.Users.Commands.UpdateUser;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Application.Users.Queries.GetAllUsers;
using CQRSpattern.Application.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSpattern.Presentation.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _sender.Send(new GetAllUsersQuery());

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Value),
                ResultStatus.NotFound => NotFound(new { message = result.Error }),
                _ => StatusCode(500)
            };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetUserByIdQuery(id));

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Value),
                ResultStatus.NotFound => NotFound(new { message = result.Error }),
                _ => StatusCode(500)
            };

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
        {
            var result = await _sender.Send(new CreateUserCommand(dto));

            return result.Status switch
            {
                ResultStatus.Success => CreatedAtAction(
                    nameof(GetUser),
                    new { id = result.Value.Id },
                    result.Value
                ),
                ResultStatus.Conflict => Conflict(new { message = result.Error }),
                _ => StatusCode(500)
            };

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserRequestDto dto)
        {
            var result = await _sender.Send(new UpdateUserCommand(id, dto));

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Value),
                ResultStatus.NotFound => NotFound(new { message = result.Error }),
                ResultStatus.Conflict => Conflict(new { message = result.Error }),
                _ => StatusCode(500)
            };
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var result = await _sender.Send(new DeleteUserCommand(id));

            return result.Status switch
            {
                ResultStatus.Success => Ok(result.Value),
                ResultStatus.NotFound => NotFound(new { message = result.Error }),
                ResultStatus.Conflict => Conflict(new { message = result.Error }),
                _ => StatusCode(500)
            };
        }
    }
}
