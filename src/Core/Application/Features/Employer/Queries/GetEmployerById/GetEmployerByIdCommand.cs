using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

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
        try
        {
            GetEmployerByIdResponse employer = _mapper.Map<GetEmployerByIdResponse>(await _employerRepository.GetByIdAsync(request.Id));
            return new ServiceResponse<GetEmployerByIdResponse>(employer) { IsSuccess = true };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<GetEmployerByIdResponse>(null) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}