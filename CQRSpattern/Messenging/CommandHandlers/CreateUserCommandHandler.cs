using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDTO>
    {
        IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateUserResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.Exist(request.user.Username, cancellationToken);

            if (userExists != null)
            {
                return new CreateUserResponseDTO
                {
                    user = null,                    // walang user object dahil may conflict
                    response = ResponseEnum.Conflict
                };
            }

            // Create new user
            var newUser = new User
            {
                Name = request.user.Name,
                Username = request.user.Username,
                Password = request.user.Password
            };

            var addedUser = await _userRepository.Add(newUser, cancellationToken);

            return new CreateUserResponseDTO
            {
                user = addedUser,
                response = ResponseEnum.Success
            };


        }
    }
}
