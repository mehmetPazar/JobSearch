using FluentValidation;

namespace Application.Features.JobPosting.Commands.DeleteJobPosting;

public class DeleteJobPostingValidator : AbstractValidator<DeleteJobPostingRequest>
{
	public DeleteJobPostingValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
    }
}