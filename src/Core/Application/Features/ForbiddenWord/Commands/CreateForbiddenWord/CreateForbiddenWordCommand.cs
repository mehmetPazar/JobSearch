using Application.Wrappers;
using AutoMapper;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;

public class CreateForbiddenWordCommand : IRequestHandler<CreateForbiddenWordRequest, ServiceResponse<long>>
{
    private readonly IForbiddenWordRepository _forbiddenWordRepository;
    private readonly IMapper _mapper;

    public CreateForbiddenWordCommand(IForbiddenWordRepository forbiddenWordRepository, IMapper mapper)
    {
        _forbiddenWordRepository = forbiddenWordRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<long>> Handle(CreateForbiddenWordRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.ForbiddenWord newForbiddenWord = _mapper.Map<Domain.Entities.ForbiddenWord>(request);
        newForbiddenWord.CreatedBy = "ADMIN";
        newForbiddenWord.Created = new DateTime();

        await _forbiddenWordRepository.AddAsync(newForbiddenWord);
        await _forbiddenWordRepository.SaveAsync();
        return new ServiceResponse<long>(newForbiddenWord.Id) { IsSuccess = true };
    }
}