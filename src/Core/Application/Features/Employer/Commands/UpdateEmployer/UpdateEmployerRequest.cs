using Application.Wrappers;
using MediatR;

namespace Application.Features.Employer.Commands.UpdateEmployer;

public class UpdateEmployerRequest : IRequest<ServiceResponse<long>>
{
    public long Id { get; set; }

    public string CompanyName { get; set; }

    public string TelephoneNumber { get; set; }

    public string Address { get; set; }

    public int NumberOfJobPostings { get; set; }
}