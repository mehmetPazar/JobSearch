using Application.Wrappers;
using MediatR;

namespace Application.Features.Employer.Commands.CreateEmployer;

public class CreateEmployerRequest : IRequest<ServiceResponse<long>>
{
    public string CompanyName { get; set; }

    public string TelephoneNumber { get; set; }

    public string Address { get; set; }
}