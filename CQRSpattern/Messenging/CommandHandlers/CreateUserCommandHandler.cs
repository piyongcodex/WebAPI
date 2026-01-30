using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models.Entities;
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
                Name = request.user.Name,
                Username = request.user.Username,
                Password = request.user.Password
            };
            return await _userRepository.Add(newUser, cancellationToken);

        }
    }
}
