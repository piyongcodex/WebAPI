using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record UpdateUserCommand(UpdateUserDTO user, Guid id) : IRequest<User>;
}

