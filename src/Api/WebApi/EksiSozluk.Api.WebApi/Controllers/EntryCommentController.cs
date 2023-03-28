using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class EntryCommentController : BaseController
{
    private IMediator _mediator;

    public EntryCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("CreateEntryComment")]
    public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}