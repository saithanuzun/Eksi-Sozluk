using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Features.Queries.EntryComment.GetEntryComments;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class EntryCommentController : BaseController
{
    private readonly IMediator _mediator;

    public EntryCommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetEntryComments(Guid id, int page, int pageSize)
    {
        var result = await _mediator
            .Send(new GetEntryCommentsQueryRequest(page, pageSize, id, userId: UserId.Value));

        return Ok(result);
    }

    [HttpPost]
    [Route("CreateEntryComment")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommandRequest request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}