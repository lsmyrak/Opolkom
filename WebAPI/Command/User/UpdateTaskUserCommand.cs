using Contracts.Dtos.Task;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class UpdateTaskUserCommand : IRequest
{
    public WorkDto _workDto { get; set; }
    public UpdateTaskUserCommand(WorkDto workDto)
    {
        _workDto = workDto;
    }
}

public class UpdateTaskUserCommandHandler : IRequestHandler<UpdateTaskUserCommand>
{
    private readonly IUserService _userService;
    public UpdateTaskUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(UpdateTaskUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateWork(request._workDto);
    }
}
