using FluentValidation;

namespace Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;

public class CreateForbiddenWordValidator : AbstractValidator<CreateForbiddenWordRequest>
{
	public CreateForbiddenWordValidator()
	{
        RuleFor(x => x.Word).NotEmpty().NotNull().WithMessage("Kelime alanı zorunludur!");
    }
}