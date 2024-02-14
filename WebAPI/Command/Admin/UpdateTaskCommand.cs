using Contracts.Dtos.Task;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class UpdateTaskCommand : IRequest
{
    public WorkDto _workDto { get; set; }

    public UpdateTaskCommand(WorkDto workDto)
    {
        _workDto = workDto;
    }
}

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
{
    private readonly IUserService _userService;

    public UpdateTaskCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateWork(request._workDto);
    }
}
