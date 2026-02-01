using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSpattern.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userRepository, ILogger<UpdateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateUserCommand started for UserId: {Id}", request.Id);

            bool exists = await _userRepository.Exist(request.Id, cancellationToken);

            if (!exists)
            {
                _logger.LogWarning("UpdateUserCommand not found: UserId {Id}", request.Id);
                return Result<UserDto>.NotFound("User not found");
            }

            var updatedUser = await _userRepository.Update(
                request.Id,
                request.User.Name,
                request.User.Username,
                request.User.Password,
                cancellationToken
            );

            _logger.LogInformation("UpdateUserCommand success: User updated. UserId: {Id}", updatedUser.Id);

            var dto = new UserDto
            {
                Id = updatedUser.Id,
                Name = updatedUser.Name,
                Username = updatedUser.Username
            };

            return Result<UserDto>.Success(dto);
        }
    }
}
