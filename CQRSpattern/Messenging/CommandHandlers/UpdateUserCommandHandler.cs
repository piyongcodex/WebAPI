using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.Update(request.user, request.id, cancellationToken);
        }
    }
}
