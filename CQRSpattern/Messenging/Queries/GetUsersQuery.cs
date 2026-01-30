using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.Queries
{
    public record GetUsersQuery: IRequest<IEnumerable<User>>;
}
