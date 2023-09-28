using FluentValidation;

namespace Application.Features.ForbiddenWord.Commands.DeleteForbiddenWord;

public class DeleteForbiddenWordValidator : AbstractValidator<DeleteForbiddenWordRequest>
{
	public DeleteForbiddenWordValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
    }
}