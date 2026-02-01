using CQRSpattern.Application.Users.Commands.CreateUser.Enums;
using CQRSpattern.Domain.Abstractions;
using CQRSpattern.Domain.Entities;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.Exist(request.User.Username, cancellationToken);

            if (userExists != null)
            {
                return new CreateUserResponse
                {
                    user = null,
                    response = ResponseStatus.Conflict
                };
            }

            var newUser = new User(
                 Guid.NewGuid(),
                 request.User.Name,
                 request.User.Username,
                 request.User.Password
             );

            var addedUser = await _userRepository.Add(newUser, cancellationToken);

            return new CreateUserResponse
            {
                user = new CreateUserResponseDto
                {
                    Id = addedUser.Id,
                    Name = addedUser.Name,
                    Username = addedUser.Username,
                    Password = addedUser.Password
                },
                response = ResponseStatus.Success
            };


        }
    }
}
