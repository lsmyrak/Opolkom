using FluentValidation;

namespace Contracts.Dtos.User.Validators;

public class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).EmailAddress(); ;
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }

}
