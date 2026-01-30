using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record UpdateUserCommand(UpdateUserDTO user, Guid id) : IRequest<User>;
}

