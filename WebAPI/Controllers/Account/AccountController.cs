﻿using Contracts.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Command;

namespace WebAPI.Controllers.Account;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task Register(RegisterUserDto registerUserDto)
    {
        if (ModelState.IsValid)
        {
            await _mediator.Send(new RegisterUserCommand(registerUserDto));
        }
        else
        {
            BadRequest(ModelState);
        }
    }

    [HttpPost("login")]
    public async Task<string> Login(LoginDto loginDto)
    {
        if (ModelState.IsValid)
        {

            return await _mediator.Send(new LoginCommand(loginDto));
        }
         return  ModelState.ToString();
    }
}
