using Contracts.Dtos.User;
using MediatR;
using System.Security.Claims;
using WebAPI.Services;

namespace WebAPI.Queries;

public class GetUserWorkQuery:IRequest<UserWorkDto>
{

}
public class GetUserWorkQueryHandler : IRequestHandler<GetUserWorkQuery, UserWorkDto>
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetUserWorkQueryHandler(IUserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
        
    }
    public  async Task<UserWorkDto> Handle(GetUserWorkQuery request, CancellationToken cancellationToken)
    {
        var idUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (idUser != null) 
        {
            return await _userService.GetUserTasksByIdAsync(Convert.ToInt32(idUser));
        }
        return null;
    }
}