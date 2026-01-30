using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record CreateUserCommand(string Name, string Username, string Password): IRequest<User>;
}
