using Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;
using Application.Features.ForbiddenWord.Commands.DeleteForbiddenWord;
using Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ForbiddenWordController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForbiddenWordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateForbiddenWordRequest command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllForbiddenWordRequest()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await _mediator.Send(new GetForbiddenWordByIdRequest { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateForbiddenWordRequest command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await _mediator.Send(new DeleteForbiddenWordRequest { Id = id }));
    }
}