using FluentValidation;

namespace EksiSozluk.Api.Application.Features.Commands.User.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommandRequest>
{
    public LoginUserCommandValidator()
    {
        RuleFor(i => i.Email)
            .NotNull()
            .EmailAddress()
            .WithMessage("{PropertyName} not a valid email address");

        RuleFor(i => i.Password)
            .NotNull()
            .MinimumLength(6)
            .WithMessage("{PropertyName} should at least be {MinLenght} characters");
    }
}