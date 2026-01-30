using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
    {
        IUserRepository _userRepository;

        public GetUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUser(request.id, cancellationToken);
        }
    }
}
