using Persistence.Repositories.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

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
        try
        {
            Domain.Entities.ForbiddenWord newForbiddenWord = _mapper.Map<Domain.Entities.ForbiddenWord>(request);
            newForbiddenWord.CreatedBy = "ADMIN";
            newForbiddenWord.Created = new DateTime();
            await _forbiddenWordRepository.AddAsync(newForbiddenWord);
            await _forbiddenWordRepository.SaveAsync();

            if (newForbiddenWord.Id > 0)
            {
                return new ServiceResponse<long>(newForbiddenWord.Id) { IsSuccess = true };
            }
            else
            {
                return new ServiceResponse<long>(newForbiddenWord.Id) { IsSuccess = false, Message = "An error occurred while performing the create request." };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse<long>(0) { IsSuccess = false, Message = ex.Message.ToString() };
        }
    }
}