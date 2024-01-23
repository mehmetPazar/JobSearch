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
        try
        {
            bool isSuccess = await _employerRepository.RemoveAsync(request.Id);

            if (isSuccess)
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
            }
            else
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess, Message = "An error occurred while performing the delete request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(request.Id) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}