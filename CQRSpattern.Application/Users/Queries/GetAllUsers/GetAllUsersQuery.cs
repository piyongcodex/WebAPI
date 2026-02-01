using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using MediatR;

namespace CQRSpattern.Application.Users.Queries.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<Result<IEnumerable<UserDto>>>;
}
