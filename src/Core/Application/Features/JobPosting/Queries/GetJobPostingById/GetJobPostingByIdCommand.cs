using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

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
        try
        {
            GetJobPostingByIdResponse jobPosting = _mapper.Map<GetJobPostingByIdResponse>(await _jobPostingRepository.GetByIdAsync(request.Id));
            return new ServiceResponse<GetJobPostingByIdResponse>(jobPosting) { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<GetJobPostingByIdResponse>(null) { IsSuccess = true, Message = ex.Message.ToString() };
        }
    }
}