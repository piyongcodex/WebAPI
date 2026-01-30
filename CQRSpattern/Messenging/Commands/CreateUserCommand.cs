using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record CreateUserCommand(AddUserDTO user): IRequest<User>;
}
