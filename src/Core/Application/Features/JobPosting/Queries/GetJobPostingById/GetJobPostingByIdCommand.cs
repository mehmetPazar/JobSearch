using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.JobPosting.Queries.GetJobPostingById;

public class GetJobPostingByIdCommand : IRequestHandler<GetJobPostingByIdRequest, ServiceResponse<GetJobPostingByIdResponse>>
{
    private readonly IJobPostingRepository _jobPostingRepository;
    private readonly IMapper _mapper;

    public GetJobPostingByIdCommand(IJobPostingRepository jobPostingRepository, IMapper mapper)
    {
        _jobPostingRepository = jobPostingRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetJobPostingByIdResponse>> Handle(GetJobPostingByIdRequest request, CancellationToken cancellationToken)
    {
        GetJobPostingByIdResponse jobPosting = _mapper.Map<GetJobPostingByIdResponse>(await _jobPostingRepository.GetByIdAsync(request.Id));
        return new ServiceResponse<GetJobPostingByIdResponse>(jobPosting) { IsSuccess = true };
    }
}