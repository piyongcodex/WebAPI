using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.Queries
{
    public record GetUserQuery(Guid id): IRequest<User>;
}
