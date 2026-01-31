using CQRSpattern.Models;
using CQRSpattern.Models.Entities;
using FluentValidation;
using MediatR;

namespace CQRSpattern.Messenging.Commands
{

    public record CreateUserCommand(AddUserDTO user): IRequest<CreateUserResponseDTO>;

    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.user)
                .NotNull();

            RuleFor(x => x.user).ChildRules(user =>
            {
                user.RuleFor(u => u.Username)
                    .NotEmpty()
                    .MinimumLength(5);

                user.RuleFor(u => u.Password)
                    .NotEmpty()
                    .MinimumLength(8);

                user.RuleFor(u => u.Name)
                    .NotEmpty();
            });
        }

    }
}
