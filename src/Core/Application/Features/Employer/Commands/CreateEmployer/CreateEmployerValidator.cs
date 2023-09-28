using FluentValidation;

namespace Application.Features.Employer.Commands.CreateEmployer;

public class CreateEmployerValidator : AbstractValidator<CreateEmployerRequest>
{
	public CreateEmployerValidator()
	{
        RuleFor(x => x.CompanyName).NotEmpty().NotNull().WithMessage("Firma adı zorunludur!");
        RuleFor(x => x.TelephoneNumber).NotEmpty().NotNull().WithMessage("Telefon numarası zorunludur!");
        RuleFor(x => x.Address).NotEmpty().NotNull().WithMessage("Address zorunludur!"); ;
    }
}