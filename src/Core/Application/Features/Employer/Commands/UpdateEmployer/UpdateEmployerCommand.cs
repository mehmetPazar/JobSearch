using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Employer.Commands.UpdateEmployer;

public class UpdateEmployerCommand : IRequestHandler<UpdateEmployerRequest, ServiceResponse<long>>
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IMapper _mapper;

    public UpdateEmployerCommand(IEmployerRepository employerRepository, IMapper mapper)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(UpdateEmployerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.Employer updateEmployer = _mapper.Map<Domain.Entities.Employer>(request);
            updateEmployer.LastModifiedBy = "ADMIN";
            updateEmployer.LastModified = new DateTime();
            bool isSuccess = await _employerRepository.UpdateAsync(updateEmployer, request.Id);

            if(isSuccess)
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess };
            }
            else
            {
                return new ServiceResponse<long>(request.Id) { IsSuccess = isSuccess, Message = "An error occurred while performing the update request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(request.Id) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}