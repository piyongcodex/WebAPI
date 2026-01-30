using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Queries;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.QueryHandlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUsers(cancellationToken);
        }
    }
}
