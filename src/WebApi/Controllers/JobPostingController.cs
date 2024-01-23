using Application.Features.JobPosting.Commands.CreateJobPosting;
using Application.Features.JobPosting.Commands.DeleteJobPosting;
using Application.Features.JobPosting.Commands.UpdateJobPosting;
using Application.Features.JobPosting.Queries.GetAllJobPosting;
using Application.Features.JobPosting.Queries.GetJobPostingById;
using Microsoft.AspNetCore.Mvc;
using Application.Wrappers;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]s")]
[ApiVersion("1.0")]
public class JobPostingController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPostingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateJobPosting")]
    public async Task<IActionResult> PostAsync(CreateJobPostingRequest command)
    {
        var response = await _mediator.Send(command);

        response.Links = GetLinks(response.Data, "\"CreateJobPosting\"").ToList();

        return CreatedAtAction("Post", new { id = response.Data }, response);
    }

    [HttpGet(Name = "GetAllJobPostings")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllJobPostingRequest());

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(null, "GetAllJobPostings").ToList();

        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetJobPostingById")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var response = await _mediator.Send(new GetJobPostingByIdRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "GetJobPostingById").ToList();

        return Ok(response);
    }

    [HttpPut("{id}", Name = "UpdateJobPosting")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateJobPostingRequest command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "UpdateJobPosting").ToList();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteJobPosting")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var response = await _mediator.Send(new DeleteJobPostingRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "DeleteJobPosting").ToList();

        return NoContent();
    }

    private IEnumerable<Link> GetLinks(long? id, string mainHref)
    {
        List<Link> links = new();

        if (id != null)
        {
            links.Add(new Link(Url.Link("GetJobPostingById", new { id }), mainHref.Equals("GetJobPostingById") ? "self" : "getById", "GET"));
            links.Add(new Link(Url.Link("UpdateJobPosting", new { id }), mainHref.Equals("UpdateJobPosting") ? "self" : "update", "PUT"));
            links.Add(new Link(Url.Link("DeleteJobPosting", new { id }), mainHref.Equals("DeleteJobPosting") ? "self" : "delete", "DELETE"));
        }

        links.Add(new Link(Url.Link("GetAllJobPostings", null), mainHref.Equals("GetAllJobPostings") ? "self" : "get", "GET"));
        links.Add(new Link(Url.Link("CreateJobPosting", null), mainHref.Equals("CreateJobPosting") ? "self" : "create", "POST"));

        return links;
    }
}