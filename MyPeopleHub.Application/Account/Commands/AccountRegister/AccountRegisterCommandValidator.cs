using FluentValidation;

namespace MyPeopleHub.Application.Account.Commands.AccountRegister
{
    public class AccountRegisterCommandValidator : AbstractValidator<AccountRegisterCommand>
    {
        public AccountRegisterCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Empty email")
                .EmailAddress().WithMessage("Text is not an email");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Empty password");

            RuleFor(x => x.Login)
                .NotEmpty().WithMessage("Empty login");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Empty first name");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Empty last name");

            RuleFor(x => x.Image)
                .Null();
        }
    }
}
