﻿using Contracts.Dtos.Task;
using Contracts.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Command;
using WebAPI.Queries;

namespace WebAPI.Controllers.User;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-self")]
    public async Task<UserWorkOnlyCalcDto> GetSelf()
    {
        return await _mediator.Send(new GetSelfOnlyCalcQuery());
    }

    [HttpGet("get-works")]
    public async Task<UserWorkDto> GetUserWork()
    {
        return await _mediator.Send(new GetUserWorkQuery());
    }

    [HttpGet("get-work-by-date")]
    public async Task<UserWorkDto> GetWorkByDate(DateOnly startDate, DateOnly endDate)
    {
        return await _mediator.Send(new GetUserWorkByScopeDate(startDate, endDate) );
    }

    [HttpPost("add-task")]
    public async Task AddTak(WorkDto workDto)
    {
        await _mediator.Send(new AddWorkToUserCommand(workDto));
    }

    [HttpDelete("delete/{idWork}")]
    public async Task DeleteTask(int idWork)
    {
        await _mediator.Send(new RemoveTaskUserCommand(idWork));
    }

    [HttpPatch("edit-task")]
    public async Task UpdateTask(WorkDto workDto)
    {
        await _mediator.Send(new UpdateTaskUserCommand(workDto));
    }
}
