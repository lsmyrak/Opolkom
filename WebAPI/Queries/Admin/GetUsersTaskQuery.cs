using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Queries;

public class GetUsersTaskQuery : IRequest<IEnumerable<UserWorkDto>>
{
    public GetUsersTaskQuery()
    {
    }
}

public class GetUsersTaskQueryHandler : IRequestHandler<GetUsersTaskQuery, IEnumerable<UserWorkDto>>
{
    private readonly IUserService _userService;
    public GetUsersTaskQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<IEnumerable<UserWorkDto>> Handle(GetUsersTaskQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetUsersWithWorksAsync();
    }
}
