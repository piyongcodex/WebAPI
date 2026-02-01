using CQRSpattern.Application.Common.Results;
using CQRSpattern.Domain.Abstractions;
using MediatR;

namespace CQRSpattern.Application.Users.Commands.DeleteUser
{

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<Guid>>
    {
        IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<Guid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            bool exist = await _userRepository.Exist(request.Id, cancellationToken);

            if (!exist)
                return Result<Guid>.NotFound("User not found");

            var result = await _userRepository.Delete(request.Id, cancellationToken);

            return Result<Guid>.Success(result);

        }
    }
}
