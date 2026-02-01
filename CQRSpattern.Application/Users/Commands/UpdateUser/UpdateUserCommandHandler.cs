using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            bool exists = await _userRepository.Exist(request.Id, cancellationToken);

            if (!exists)
                return Result<UserDto>.NotFound("User not found");

            var updatedUser = await _userRepository.Update(
                request.Id,
                request.User.Name,
                request.User.Username,
                request.User.Password,
                cancellationToken
            );

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
