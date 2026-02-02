using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using CQRSpattern.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        IUserRepository _userRepository;

        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userRepository, ILogger<CreateUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            bool exist = await _userRepository.Exist(request.User.Username, cancellationToken);

            if (exist)
            {
                _logger.LogWarning("CreateUserCommand conflict: User creation failed: Username '{Username}' already exists", request.User.Username);
                return Result<UserDto>.Conflict("Username already exist");
            }

            var newUser = new User(
                Guid.NewGuid(),
                request.User.Name,
                request.User.Username,
                request.User.Password
            );

            var createdUser = await _userRepository.Add(newUser, cancellationToken);

            _logger.LogInformation("CreateUserCommand success: User created. UserId: {UserId}, Username: {Username}",
                createdUser.Id, createdUser.Username);

            var dto = new UserDto
            {
                Id = createdUser.Id,
                Name = createdUser.Name,
                Username = createdUser.Username
            };

            return Result<UserDto>.Success(dto);
        }
    }
}
