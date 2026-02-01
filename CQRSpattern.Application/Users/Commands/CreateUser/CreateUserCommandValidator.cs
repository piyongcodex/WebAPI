using FluentValidation;

namespace CQRSpattern.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.User)
                .NotNull()
                .WithMessage("User information is required.");

            RuleFor(x => x.User).ChildRules(user =>
            {
                user.RuleFor(u => u.Username)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(20)
                    .Matches("^[a-zA-Z0-9_.-]+$")
                    .WithMessage("Username must be 5-20 characters and contain only letters, numbers, and ._-");

                user.RuleFor(u => u.Password)
                    .NotEmpty()
                    .MinimumLength(8)
                    .MaximumLength(128)
                    .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                    .Matches(@"[\!\?\*\.\@\#\$\%\^\&\+\=]+")
                    .WithMessage("Password must contain at least one special character (!?*.@#$%^&+=).");

                user.RuleFor(u => u.Name)
                    .NotEmpty()
                    .MaximumLength(50)
                    .WithMessage("Name is required and cannot exceed 50 characters.");
            });
        }
    }

}