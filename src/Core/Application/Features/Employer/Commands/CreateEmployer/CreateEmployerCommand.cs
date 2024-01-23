using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Employer.Commands.CreateEmployer;

public class CreateEmployerCommand : IRequestHandler<CreateEmployerRequest, ServiceResponse<long>>
{
    private readonly IEmployerRepository _employerRepository;
    private readonly IMapper _mapper;

    public CreateEmployerCommand(IEmployerRepository employerRepository, IMapper mapper)
    {
        _employerRepository = employerRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(CreateEmployerRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Employer newEmployer = _mapper.Map<Domain.Entities.Employer>(request);
        newEmployer.NumberOfJobPostings = 2;
        newEmployer.CreatedBy = "ADMIN";
        newEmployer.Created = new DateTime();
        await _employerRepository.AddAsync(newEmployer);
        await _employerRepository.SaveAsync();

        return newEmployer.Id > 0 
            ? new ServiceResponse<long>(newEmployer.Id) { IsSuccess = true } 
            : new ServiceResponse<long>(newEmployer.Id) { IsSuccess = true, Message = "An error occurred while performing the create request." };
    }
}