using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.Commands.CreateUser.Enums;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using CQRSpattern.Domain.Entities;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserDto>>
    {
        IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            bool exist = await _userRepository.Exist(request.User.Username, cancellationToken);

            if (exist)
                return Result<UserDto>.Conflict("Username already exist");


            var newUser = new User(
                 Guid.NewGuid(),
                 request.User.Name,
                 request.User.Username,
                 request.User.Password
             );

            var createdUser = await _userRepository.Add(newUser, cancellationToken);

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
