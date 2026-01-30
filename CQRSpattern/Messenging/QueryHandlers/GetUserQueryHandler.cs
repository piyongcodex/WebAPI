using CQRSpattern.Contracts;
using CQRSpattern.Messenging.Queries;
using CQRSpattern.Models.Entities;
using MediatR;

namespace CQRSpattern.Messenging.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUser(request.id, cancellationToken);
        }
    }
}
