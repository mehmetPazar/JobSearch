using Application.Wrappers;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Employer.Commands.DeleteEmployer;

public class DeleteEmployerCommand : IRequestHandler<DeleteEmployerRequest, ServiceResponse<long>>
{
    private readonly IEmployerRepository _employerRepository;

    public DeleteEmployerCommand(IEmployerRepository employerRepository)
    {
        _employerRepository = employerRepository;
    }

    public async Task<ServiceResponse<long>> Handle(DeleteEmployerRequest request, CancellationToken cancellationToken)
    {
        bool isSuccess = await _employerRepository.RemoveAsync(request.Id);
        return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
    }
}