using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;

namespace CQRSpattern.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<IEnumerable<UserDto>>> Handle(
         GetAllUsersQuery request,
         CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers(cancellationToken);

            var dtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username
            });

            return Result<IEnumerable<UserDto>>.Success(dtos);
        }
    }
}
