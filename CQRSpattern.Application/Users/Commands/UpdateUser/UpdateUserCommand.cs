using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(Guid Id, UpdateUserRequestDto User) : IRequest<Result<UserDto>>;
}
