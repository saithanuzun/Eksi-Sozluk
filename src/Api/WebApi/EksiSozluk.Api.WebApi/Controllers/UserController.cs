using EksiSozluk.Api.Application.Features.Commands.User.Create;
using EksiSozluk.Api.Application.Features.Commands.User.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.Api.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
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
}