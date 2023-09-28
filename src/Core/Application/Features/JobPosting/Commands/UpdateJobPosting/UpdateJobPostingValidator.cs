using FluentValidation;

namespace Application.Features.JobPosting.Commands.UpdateJobPosting;

public class UpdateJobPostingValidator : AbstractValidator<UpdateJobPostingRequest>
{
	public UpdateJobPostingValidator()
	{
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı zorunludur!");
    }
}