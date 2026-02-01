using MediatR;

namespace CQRSpattern.Application.Users.Queries
{
    public record GetUserQuery(Guid Id) : IRequest<GetUserQueryResponse>;
}
