using Application.Features.JobPosting.Commands.CreateJobPosting;
using Application.Features.JobPosting.Commands.DeleteJobPosting;
using Application.Features.JobPosting.Commands.UpdateJobPosting;
using Application.Features.JobPosting.Queries.GetAllJobPosting;
using Application.Features.JobPosting.Queries.GetJobPostingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobPostingController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CreateJobPostingRequest command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllJobPostingRequest()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(await _mediator.Send(new GetJobPostingByIdRequest { Id = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateJobPostingRequest command)
    {
        command.Id = id;
        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(await _mediator.Send(new DeleteJobPostingRequest { Id = id }));
    }
}