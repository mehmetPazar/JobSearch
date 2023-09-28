using Application.Wrappers;
using MediatR;

namespace Application.Features.Employer.Commands.DeleteEmployer;

public class DeleteEmployerRequest : IRequest<ServiceResponse<long>>
{
    public long Id { get; set; }
}