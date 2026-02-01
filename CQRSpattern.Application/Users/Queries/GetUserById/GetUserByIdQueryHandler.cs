using CQRSpattern.Application.Common.Results;
using CQRSpattern.Application.Users.DTOs;
using CQRSpattern.Domain.Abstractions;
using MediatR;

namespace CQRSpattern.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.Id, cancellationToken);

            if (user == null)
                return Result<UserDto>.NotFound("User not found");

            var dto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
            };

            return Result<UserDto>.Success(dto);
        }
    }
}
