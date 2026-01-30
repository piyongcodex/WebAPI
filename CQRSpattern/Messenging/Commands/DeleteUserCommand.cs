using MediatR;

namespace CQRSpattern.Messenging.Commands
{
    public record DeleteUserCommand(Guid id): IRequest<bool>;
}
