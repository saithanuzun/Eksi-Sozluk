using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class EntryController : BaseController
{
    private IMediator _mediator;

    public EntryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("CreateEntry")]
    public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}