using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record GetUsersCommand: IRequest<IEnumerable<User>>;
}
