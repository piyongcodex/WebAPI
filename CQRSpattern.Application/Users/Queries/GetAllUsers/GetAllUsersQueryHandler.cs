using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSpattern.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(IUserRepository userRepository, ILogger<GetAllUsersQueryHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<UserDto>>> Handle(
            GetAllUsersQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAllUsersQuery started");

            var users = await _userRepository.GetAllUsers(cancellationToken);

            var dtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username
            });

            _logger.LogInformation("GetAllUsersQuery success: {Count} users retrieved", dtos.Count());

            return Result<IEnumerable<UserDto>>.Success(dtos);
        }
    }
}
