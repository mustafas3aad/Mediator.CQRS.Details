using FluentValidation;
using Mediator.CQRS.Commands;

namespace Mediator.CQRS.Validations
{
    //Note:
    //this is (pre)
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(o => o.Id).NotEqual(0).WithMessage("Id must be greater than 0.");
            RuleFor(o=>o.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(o=>o.LastName).NotEmpty().WithMessage("Last name is required.");

        }
    }
}
