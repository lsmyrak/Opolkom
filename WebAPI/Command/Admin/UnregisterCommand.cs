﻿using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class UnregisterCommand : IRequest
{
    public int Id { get; set; }
    public UnregisterCommand(int id)
    {
        Id = id;
    }
}

public class UnregisterCommandHandler : IRequestHandler<UnregisterCommand>
{
    private readonly IAccountService _accountService;
    public UnregisterCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task Handle(UnregisterCommand request, CancellationToken cancellationToken)
    {
        await _accountService.UnregisterAsync(request.Id);
    }
}
