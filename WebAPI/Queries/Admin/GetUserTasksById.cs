using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Queries
{
    public class GetUserTasksById : IRequest<UserWorkDto>
    {
        public int Id { get; set; }
        public GetUserTasksById(int id)
        {
            Id = id;
        }
    }

    public class GetUserTasksByIdHandler : IRequestHandler<GetUserTasksById, UserWorkDto>
    {
        private readonly IUserService _userService;
        public GetUserTasksByIdHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserWorkDto> Handle(GetUserTasksById request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserTasksByIdAsync(request.Id);
        }
    }
}
