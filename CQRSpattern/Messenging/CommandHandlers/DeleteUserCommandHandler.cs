using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.Delete(request.id, cancellationToken);
        }
    }
}
