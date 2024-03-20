using AutoMapper;
using Contracts.Dtos.User;
using MediatR;
using System.Security.Claims;
using WebAPI.Services;

namespace WebAPI.Queries;

public class GetSelfOnlyCalcQuery : IRequest<UserWorkOnlyCalcDto>
{
}

public class GetSelfOnlyCalcQueryHandler : IRequestHandler<GetSelfOnlyCalcQuery, UserWorkOnlyCalcDto>
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAcessor;
    private readonly IMapper _mapper;
    public GetSelfOnlyCalcQueryHandler(IUserService userService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _userService = userService;
        _httpContextAcessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<UserWorkOnlyCalcDto> Handle(GetSelfOnlyCalcQuery request, CancellationToken cancellationToken)
    {
        string idUser = _httpContextAcessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (idUser != null)
        {
            var userWorkDto = await _userService.GetUserDtoWithWorksAsync(Convert.ToInt32(idUser));
            var retVal = _mapper.Map<UserWorkOnlyCalcDto>(userWorkDto);
            return retVal;
        }
        else
            return null;

    }
}
