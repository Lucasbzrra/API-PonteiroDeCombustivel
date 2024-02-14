using Application.UserCases.Command;
using FluentValidation;


namespace Application.UserCases;

public sealed class CreateUserValidator : AbstractValidator<CreateLoginRequest>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Email).NotEmpty().MaximumLength(50).EmailAddress();
        RuleFor(user => user.UserName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(user => user.Password).NotEmpty().MaximumLength(11).MinimumLength(11).Matches("[A-Z]").Matches("[!@#$%^&*()]");
        RuleFor(user => user.RePassword).Equal(user => user.RePassword).WithMessage("Senha indiferents");
    }
}
