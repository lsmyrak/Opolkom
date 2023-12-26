using Contracts.Dtos.User;
using MediatR;
using WebAPI.Services;

namespace WebAPI.Queries;

public class GetUserQuery : IRequest<UserDto>
{
    public int Id { get; set; }

    public GetUserQuery(int id)
    {
        Id = id;
    }
}

public class GetUserQueryHander : IRequestHandler<GetUserQuery, UserDto>
{
    private readonly IUserService _userService;
    public GetUserQueryHander(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _userService.GetUserByIdAsync(request.Id);
    }
}
