using Application.Features.Employer.Commands.CreateEmployer;
using Application.Features.Employer.Commands.DeleteEmployer;
using Application.Features.Employer.Commands.UpdateEmployer;
using Application.Features.Employer.Queries.GetAllEmployer;
using Application.Features.Employer.Queries.GetEmployerById;
using Microsoft.AspNetCore.Mvc;
using Application.Wrappers;
using FluentValidation;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]s")]
[ApiVersion("1.0")]
public class EmployerController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateEmployer")]
    public async Task<IActionResult> PostAsync(CreateEmployerRequest command)
    {
        // try
        // {
            var response = await _mediator.Send(command);
        
            response.Links = GetLinks(response.Data, "CreateEmployer").ToList();

            return CreatedAtAction("Post", new { id = response.Data }, response);
        // }
        // catch (ValidationException ex)
        // {
        //     return BadRequest(ex.Errors);
        // }
    }

    [HttpGet(Name = "GetAllEmployers")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllEmployerRequest());
        
        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(null, "GetAllEmployers").ToList();

        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetEmployerById")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var response = await _mediator.Send(new GetEmployerByIdRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "GetEmployerById").ToList();

        return Ok(response);
    }

    [HttpPut("{id}", Name = "UpdateEmployer")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateEmployerRequest command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "UpdateEmployer").ToList();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteEmployer")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var response = await _mediator.Send(new DeleteEmployerRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "DeleteEmployer").ToList();

        return NoContent();
    }

    private IEnumerable<Link> GetLinks(long? id, string mainHref)
    {
        List<Link> links = new();

        if (id != null)
        {
            links.Add(new Link(Url.Link("GetEmployerById", new { id }), mainHref.Equals("GetEmployerById") ? "self" : "getById", "GET"));
            links.Add(new Link(Url.Link("UpdateEmployer", new { id }), mainHref.Equals("UpdateEmployer") ? "self" : "update", "PUT"));
            links.Add(new Link(Url.Link("DeleteEmployer", new { id }), mainHref.Equals("DeleteEmployer") ? "self" : "delete", "DELETE"));
        }

        links.Add(new Link(Url.Link("GetAllEmployers", null), mainHref.Equals("GetAllEmployers") ? "self" : "get", "GET"));
        links.Add(new Link(Url.Link("CreateEmployer", null), mainHref.Equals("CreateEmployer") ? "self" : "create", "POST"));

        return links;
    }
}