using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Commands;
using CQRSpattern.Models;
using MediatR;

namespace CQRSpattern.Messenging.CommandHandlers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, IEnumerable<User>>
    {
        IUserRepository _userRepository;

        public GetUsersCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers(cancellationToken);
        }
    }
}
