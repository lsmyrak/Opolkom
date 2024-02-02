using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class DeleteTaskCommand : IRequest
{
    public int _idWork { get; set; }
    public DeleteTaskCommand(int idwork)
    {
        _idWork = idwork;
    }
}

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
{
    private readonly IUserService _userService;
    public DeleteTaskCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteWork(request._idWork);
    }
}

