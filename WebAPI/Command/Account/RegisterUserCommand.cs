using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class RegisterUserCommand : IRequest
{
    public RegisterUserDto _registerUserDto { get; set; }
    public RegisterUserCommand(RegisterUserDto registerUserDto)
    {
        _registerUserDto = registerUserDto;
    }
}

public class RegisterUserCpommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IAccountService _accountService;
    public RegisterUserCpommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _accountService.RegisterAsync(request._registerUserDto);
    }
}
