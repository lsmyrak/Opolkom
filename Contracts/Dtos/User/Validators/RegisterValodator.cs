using FluentValidation;

namespace Contracts.Dtos.User.Validators;

public class RegisterValodator : AbstractValidator<RegisterUserDto>
{
    public RegisterValodator()
    {
        RuleFor(c => c.FirstName).NotEmpty().Length(2, 100).NotEqual("-");
        RuleFor(c => c.LastName).NotEmpty().Length(2, 100).NotEqual("-");
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.Password).MinimumLength(13).Equal(c => c.ConfirmPassword);
        RuleFor(c => c.ConfirmPassword).MinimumLength(13).Equal(c => c.Password);
    }
}
