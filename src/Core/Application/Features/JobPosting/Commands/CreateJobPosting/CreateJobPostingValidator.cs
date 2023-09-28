using FluentValidation;

namespace Application.Features.JobPosting.Commands.CreateJobPosting;

public class CreateJobPostingValidator : AbstractValidator<CreateJobPostingRequest>
{
	public CreateJobPostingValidator()
	{
        RuleFor(x => x.Position).NotEmpty().NotNull().WithMessage("İlan için pozisyon zorunludur!");
        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("İlan için açıklama zorunludur!");
    }
}