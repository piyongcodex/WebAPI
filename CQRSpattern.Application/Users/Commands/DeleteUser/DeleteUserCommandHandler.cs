using CQRSpattern.Application.Common.Results;
using CQRSpattern.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRSpattern.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<Guid>>
    {
        private readonly ILogger<DeleteUserCommandHandler> _logger;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<Result<Guid>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DeleteUserCommand started for UserId: {Id}", request.Id);

            bool exist = await _userRepository.Exist(request.Id, cancellationToken);

            if (!exist)
            {
                _logger.LogWarning("DeleteUserCommand not found: UserId {Id}", request.Id);
                return Result<Guid>.NotFound("User not found");
            }

            var deletedUserId = await _userRepository.Delete(request.Id, cancellationToken);

            _logger.LogInformation("DeleteUserCommand success: User deleted. UserId: {Id}", deletedUserId);

            return Result<Guid>.Success(deletedUserId);
        }
    }
}
