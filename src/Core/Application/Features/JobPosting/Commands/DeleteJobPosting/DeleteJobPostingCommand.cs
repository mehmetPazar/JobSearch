using Application.Wrappers;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.JobPosting.Commands.DeleteJobPosting;

public class DeleteJobPostingCommand : IRequestHandler<DeleteJobPostingRequest, ServiceResponse<long>>
{
    private readonly IJobPostingRepository _jobPostingRepository;

    public DeleteJobPostingCommand(IJobPostingRepository jobPostingRepository)
    {
        _jobPostingRepository = jobPostingRepository;
    }

    public async Task<ServiceResponse<long>> Handle(DeleteJobPostingRequest request, CancellationToken cancellationToken)
    {
        bool isSuccess = await _jobPostingRepository.RemoveAsync(request.Id);
        return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
    }
}