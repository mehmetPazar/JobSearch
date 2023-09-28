using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.JobPosting.Commands.CreateJobPosting;

public class CreateJobPostingCommand : IRequestHandler<CreateJobPostingRequest, ServiceResponse<long>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public CreateJobPostingCommand(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(CreateJobPostingRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.JobPosting newJobPosting = _mapper.Map<Domain.Entities.JobPosting>(request);
        newJobPosting.CreatedBy = "ADMIN";
        newJobPosting.Created = new DateTime();

        await _jobPostingRepository.AddAsync(newJobPosting);
        await _jobPostingRepository.SaveAsync();
        return new ServiceResponse<long>(newJobPosting.Id) { IsSuccess = true };
    }
}