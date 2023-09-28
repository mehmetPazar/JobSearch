using FluentValidation;

namespace Application.Features.Employer.Commands.DeleteEmployer;

public class DeleteEmployerValidator : AbstractValidator<DeleteEmployerRequest>
{
	public DeleteEmployerValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
    }
}