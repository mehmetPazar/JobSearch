using Application.Features.Employer.Commands.DeleteEmployer;
using FluentValidation;

namespace Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;

public class UpdateForbiddenWordValidator : AbstractValidator<UpdateForbiddenWordRequest>
{
	public UpdateForbiddenWordValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
        RuleFor(x => x.Word).NotEmpty().NotNull().WithMessage("Kelime alanı zorunludur!");
    }
}