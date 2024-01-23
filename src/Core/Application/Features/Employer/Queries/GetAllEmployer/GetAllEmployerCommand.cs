using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Employer.Queries.GetAllEmployer;

public class GetAllEmployerCommand : IRequestHandler<GetAllEmployerRequest, ServiceResponse<List<GetAllEmployerResponse>>>
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IMapper _mapper;

    public GetAllEmployerCommand(IEmployerRepository employerRepository, IMapper mapper)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetAllEmployerResponse>>> Handle(GetAllEmployerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            List<GetAllEmployerResponse> employers = _mapper.Map<List<GetAllEmployerResponse>>(await _employerRepository.GetAsync());
            return new ServiceResponse<List<GetAllEmployerResponse>>(employers) { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<GetAllEmployerResponse>>(null) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}