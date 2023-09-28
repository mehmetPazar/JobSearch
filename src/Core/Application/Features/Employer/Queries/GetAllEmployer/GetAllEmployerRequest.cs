using Application.Wrappers;
using MediatR;

namespace Application.Features.Employer.Queries.GetAllEmployer;

public class GetAllEmployerRequest : IRequest<ServiceResponse<List<GetAllEmployerResponse>>>
{
    
}