using CQRSpattern.Application.Common.Results;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(Guid Id): IRequest<Result<Guid>>;
}
