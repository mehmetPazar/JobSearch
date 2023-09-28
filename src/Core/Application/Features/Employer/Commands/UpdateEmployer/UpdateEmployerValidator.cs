using FluentValidation;

namespace Application.Features.Employer.Commands.UpdateEmployer;

public class UpdateEmployerValidator : AbstractValidator<UpdateEmployerRequest>
{
	public UpdateEmployerValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
    }
}