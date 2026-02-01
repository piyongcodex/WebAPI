using CQRSpattern.Domain.Abstractions;
using MediatR;

namespace CQRSpattern.Application.Users.Queries
{

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUser(request.Id, cancellationToken);



            return new GetUserQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Name,
                Password = user.Password,
            };


        }
    }

}
