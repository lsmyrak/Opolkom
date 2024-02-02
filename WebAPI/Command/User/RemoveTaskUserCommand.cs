using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class RemoveTaskUserCommand : IRequest
    {
        public int idWork { get; set; }
        public RemoveTaskUserCommand(int idWork)
        {

            this.idWork = idWork;

        }
    }

    public class RemoveTaskUserCommandHandler : IRequestHandler<RemoveTaskUserCommand>
    {
        private readonly IUserService _userService;
        public RemoveTaskUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task Handle(RemoveTaskUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.DeleteWork(request.idWork);
        }
    }
}
