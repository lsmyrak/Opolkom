using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserDto>>
    {
        public GetUsersQuery()
        {

        }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserService _userService;
        public GetUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersDtoAsync();
        }
    }
}
