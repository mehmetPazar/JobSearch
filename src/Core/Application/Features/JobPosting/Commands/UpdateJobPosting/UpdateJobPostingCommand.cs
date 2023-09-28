using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.JobPosting.Commands.UpdateJobPosting;

public class UpdateJobPostingCommand : IRequestHandler<UpdateJobPostingRequest, ServiceResponse<long>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public UpdateJobPostingCommand(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(UpdateJobPostingRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.JobPosting updateJobPosting = _mapper.Map<Domain.Entities.JobPosting>(request);
        updateJobPosting.LastModifiedBy = "ADMIN";
        updateJobPosting.LastModified = new DateTime();

        bool isSuccess = await _jobPostingRepository.UpdateAsync(updateJobPosting, request.Id);
        return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
    }
}