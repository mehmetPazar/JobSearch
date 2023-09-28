using Application.Wrappers;
using MediatR;

namespace Application.Features.Employer.Queries.GetEmployerById;

public class GetEmployerByIdRequest : IRequest<ServiceResponse<GetEmployerByIdResponse>>
{
    public long Id { get; set; }
}