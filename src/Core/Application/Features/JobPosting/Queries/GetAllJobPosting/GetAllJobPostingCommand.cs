using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.JobPosting.Queries.GetAllJobPosting;

public class GetAllJobPostingCommand : IRequestHandler<GetAllJobPostingRequest, ServiceResponse<List<GetAllJobPostingResponse>>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public GetAllJobPostingCommand(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetAllJobPostingResponse>>> Handle(GetAllJobPostingRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<GetAllJobPostingResponse> jobPostings = _mapper.Map<List<GetAllJobPostingResponse>>(await _jobPostingRepository.GetAsync());
            return new ServiceResponse<List<GetAllJobPostingResponse>>(jobPostings) { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<GetAllJobPostingResponse>>(null) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}