using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Employer.Queries.GetEmployerById;

public class GetEmployerByIdCommand : IRequestHandler<GetEmployerByIdRequest, ServiceResponse<GetEmployerByIdResponse>>
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IMapper _mapper;

    public GetEmployerByIdCommand(IEmployerRepository employerRepository, IMapper mapper)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetEmployerByIdResponse>> Handle(GetEmployerByIdRequest request, CancellationToken cancellationToken)
    {
        GetEmployerByIdResponse employer = _mapper.Map<GetEmployerByIdResponse>(await _employerRepository.GetByIdAsync(request.Id));
        return new ServiceResponse<GetEmployerByIdResponse>(employer) { IsSuccess = true };
    }
}