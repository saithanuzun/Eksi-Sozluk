using EksiSozluk.Api.Application.Features.Commands.User.ChangePassword;
using EksiSozluk.Api.Application.Features.Commands.User.ConfirmEmail;
using EksiSozluk.Api.Application.Features.Commands.User.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Login;
using EksiSozluk.Api.Application.Features.Commands.User.Update;
using EksiSozluk.Api.Application.Features.Queries.User.GetUserDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _mediator.Send(new GetUserDetailsQueryRequest(){UserId = id});

        return Ok(user);
    }
    [HttpGet]
    [Route("UserName/{userName}")]
    public async Task<IActionResult> GetByUserName(string userName)
    {
        var user = await _mediator.Send(new GetUserDetailsQueryRequest(){Username = userName,UserId = null});

        return Ok(user);
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest commandRequest)
    {
        var result = await _mediator.Send(commandRequest);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommandRequest command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
    [HttpPost]
    [Route("Confirm")]
    public async Task<IActionResult> ConfirmEMail(Guid id)
    {
        var response = await _mediator.Send(new ConfirmEmailCommandRequest() { ConfirmationId = id });

        return Ok(response);
    }

    [HttpPost]
    [Route("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommandRequest command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}