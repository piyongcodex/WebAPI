using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using MediatR;

namespace CQRSpattern.Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<Result<UserDto>>;
}
