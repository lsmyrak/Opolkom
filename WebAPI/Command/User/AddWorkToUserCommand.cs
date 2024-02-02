using Contracts.Dtos.Task;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Command;

public class AddWorkToUserCommand : IRequest
{
    public WorkDto _workDto { get; set; }
    public AddWorkToUserCommand(WorkDto workDto)
    {
        _workDto = workDto;
    }
}

public class AddWorkToUserCommandHandler : IRequestHandler<AddWorkToUserCommand>
{
    private readonly IUserService _userService;
    public AddWorkToUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(AddWorkToUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.AddWorkToUser(request._workDto);
    }
}