using FluentValidation;

namespace Application.Features.Employer.Commands.CreateEmployer;

public class CreateEmployerValidator : AbstractValidator<CreateEmployerRequest>
{
	public CreateEmployerValidator()
	{
        RuleFor(x => x.CompanyName).NotEmpty().NotNull().WithMessage("Company name is required!");
        RuleFor(x => x.TelephoneNumber).NotEmpty().NotNull().WithMessage("Phone number is required!");
        RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("Address is required!");
    }
}