using EksiSozluk.Api.Application.Features.Commands.Entry.Create;
using EksiSozluk.Api.Application.Features.Queries.Entry.GetEntries;
using EksiSozluk.Api.Application.Features.Queries.Entry.GetEntryDetails;
using EksiSozluk.Api.Application.Features.Queries.Entry.GetMainPageEntries;
using EksiSozluk.Api.Application.Features.Queries.Search;
using EksiSozluk.Api.Application.Features.Queries.User.GetUserEntries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class EntryController : BaseController
{
    private readonly IMediator _mediator;

    public EntryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = _mediator.Send(new GetEntryDetailsQueryRequest { EntryId = id, UserId = UserId });
        return Ok(response);
    }

    [HttpPost]
    [Route("CreateEntry")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
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

    [Route("MainPageEntries")]
    [HttpGet]
    public async Task<IActionResult> GetMainPageEntries(int page, int pageSize)
    {
        
        var response = await _mediator.Send(new GetMainPageEntriesQueryRequest(null, page, pageSize));
        return Ok(response);
    }

    [HttpGet]
    [Route("UserEntries")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetUserEntries(string userName, Guid userId, int page, int pageSize)
    {
        if (userId == Guid.Empty && string.IsNullOrEmpty(userName))
            userId = UserId.Value;

        var result = await _mediator.Send(new GetUserEntriesQueryRequest(userId, userName, page, pageSize));

        return Ok(result);
    }

    [HttpGet]
    [Route("Search")]
    public async Task<IActionResult> Search([FromQuery] SearchRequest query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}