using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record GetUserCommand(Guid id): IRequest<User>;
}
