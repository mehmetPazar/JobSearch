using Application.Features.ForbiddenWord.Commands.CreateForbiddenWord;
using Application.Features.ForbiddenWord.Commands.DeleteForbiddenWord;
using Application.Features.ForbiddenWord.Commands.UpdateForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetAllForbiddenWord;
using Application.Features.ForbiddenWord.Queries.GetForbiddenWordById;
using Microsoft.AspNetCore.Mvc;
using Application.Wrappers;
using MediatR;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]s")]
[ApiVersion("1.0")]
public class ForbiddenWordController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForbiddenWordController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "CreateForbiddenWord")]
    public async Task<IActionResult> PostAsync(CreateForbiddenWordRequest command)
    {
        var response = await _mediator.Send(command);

        response.Links = GetLinks(response.Data, "CreateForbiddenWord").ToList();

        return CreatedAtAction("Post", new { id = response.Data }, response);
    }

    [HttpGet(Name = "GetAllForbiddenWords")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await _mediator.Send(new GetAllForbiddenWordRequest());

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(null, "GetAllForbiddenWords").ToList();

        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetForbiddenWordById")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        var response = await _mediator.Send(new GetForbiddenWordByIdRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "GetForbiddenWordById").ToList();

        return Ok(response);
    }

    [HttpPut("{id}", Name = "UpdateForbiddenWord")]
    public async Task<IActionResult> UpdateAsync(long id, UpdateForbiddenWordRequest command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "UpdateForbiddenWord").ToList();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteForbiddenWord")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var response = await _mediator.Send(new DeleteForbiddenWordRequest { Id = id });

        if (!response.IsSuccess)
            return NotFound();

        response.Links = GetLinks(id, "DeleteForbiddenWord").ToList();

        return NoContent();
    }

    private IEnumerable<Link> GetLinks(long? id, string mainHref)
    {
        List<Link> links = new();

        if (id != null)
        {
            links.Add(new Link(Url.Link("GetForbiddenWordById", new { id }), mainHref.Equals("GetForbiddenWordById") ? "self" : "getById", "GET"));
            links.Add(new Link(Url.Link("UpdateForbiddenWord", new { id }), mainHref.Equals("UpdateForbiddenWord") ? "self" : "update", "PUT"));
            links.Add(new Link(Url.Link("DeleteForbiddenWord", new { id }), mainHref.Equals("DeleteForbiddenWord") ? "self" : "delete", "DELETE"));
        }

        links.Add(new Link(Url.Link("GetAllForbiddenWords", null), mainHref.Equals("GetAllForbiddenWords") ? "self" : "get", "GET"));
        links.Add(new Link(Url.Link("CreateForbiddenWord", null), mainHref.Equals("CreateForbiddenWord") ? "self" : "create", "POST"));

        return links;
    }
}