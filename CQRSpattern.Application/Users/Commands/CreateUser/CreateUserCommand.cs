using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Entities;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{
   public record CreateUserCommand(UserDto User): IRequest<Result<UserDto>>;
}
