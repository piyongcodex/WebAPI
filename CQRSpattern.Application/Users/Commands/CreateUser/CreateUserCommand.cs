using MediatR;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{

   public record CreateUserCommand(CreateUserRequest User): IRequest<CreateUserResponse>;
}
