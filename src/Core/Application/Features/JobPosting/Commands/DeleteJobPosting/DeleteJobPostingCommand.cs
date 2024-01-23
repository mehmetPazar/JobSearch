using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using MediatR;

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
        try
        {
            bool isSuccess = await _jobPostingRepository.RemoveAsync(request.Id);

            if(isSuccess)
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
            }
            else
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess, Message = "An error occurred while performing the delete request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(request.Id) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}