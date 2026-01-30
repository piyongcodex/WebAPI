using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Name = request.Name,
                Username = request.Username,
                Password = request.Password
            };
            return await _userRepository.Add(newUser, cancellationToken);

        }
    }
}
