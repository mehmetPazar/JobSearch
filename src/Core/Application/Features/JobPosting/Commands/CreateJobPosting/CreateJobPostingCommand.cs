using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

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
        try
        {
            Domain.Entities.JobPosting newJobPosting = _mapper.Map<Domain.Entities.JobPosting>(request);
            newJobPosting.CreatedBy = "ADMIN";
            newJobPosting.Created = new DateTime();
            await _jobPostingRepository.AddAsync(newJobPosting);
            await _jobPostingRepository.SaveAsync();

            if(newJobPosting.Id > 0)
            {
                return new ServiceResponse<long>(newJobPosting.Id) { IsSuccess = true };
            }
            else
            {
                return new ServiceResponse<long>(newJobPosting.Id) { IsSuccess = false, Message = "An error occurred while performing the create request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(0) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}