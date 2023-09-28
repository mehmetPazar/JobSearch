using Application.Features.Employer.Commands.CreateEmployer;
using Application.Features.Employer.Commands.DeleteEmployer;
using Application.Features.Employer.Commands.UpdateEmployer;
using Application.Features.Employer.Queries.GetAllEmployer;
using Application.Features.Employer.Queries.GetEmployerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployerController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateEmployerRequest command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllEmployerRequest()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await _mediator.Send(new GetEmployerByIdRequest { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateEmployerRequest command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await _mediator.Send(new DeleteEmployerRequest { Id = id }));
    }
}