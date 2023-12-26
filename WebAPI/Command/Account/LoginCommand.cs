using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class LoginCommand : IRequest<string>
    {
        public LoginDto _loginDto { get; set; }
        public LoginCommand(LoginDto loginDto)
        {
            _loginDto = loginDto;
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IAccountService _accountService;
        public LoginCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.LoginAsync(request._loginDto);
        }
    }
}
