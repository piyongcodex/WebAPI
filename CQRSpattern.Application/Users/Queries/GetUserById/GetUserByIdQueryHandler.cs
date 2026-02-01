using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSpattern.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserRepository userRepository, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUser(request.Id, cancellationToken);

            if (user == null)
            {
                _logger.LogWarning("GetUserByIdQuery not found: UserId {Id}", request.Id);
                return Result<UserDto>.NotFound("User not found");
            }

            var dto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username
            };

            _logger.LogInformation("GetUserByIdQuery success: User found. UserId: {Id}", user.Id);

            return Result<UserDto>.Success(dto);
        }
    }
}
