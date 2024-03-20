using AutoMapper;
using Contracts.Dtos.User;
using MediatR;
using System.Security.Claims;
using WebAPI.Services;

namespace WebAPI.Queries
{
    public class GetUserWorkByScopeDate:IRequest<UserWorkDto>
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public GetUserWorkByScopeDate(DateOnly startDate, DateOnly endDate)
        {
            StartDate = startDate;
            EndDate = endDate;            
        }
    }

    public class GetUserWorkByScopeDateHandler : IRequestHandler<GetUserWorkByScopeDate,UserWorkDto>
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _contextAccessor;
        public GetUserWorkByScopeDateHandler(IUserService userService,IHttpContextAccessor contextAccessor)
        {
            _userService = userService;
            _contextAccessor = contextAccessor;
        }
        public async  Task<UserWorkDto> Handle(GetUserWorkByScopeDate request, CancellationToken cancellationToken)
        {
            var idUser = _contextAccessor.HttpContext.Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(idUser == null) 
            {
                throw new BadHttpRequestException("not loged user");
            }
            var userWorksDto = await _userService.GetUserDtoWithWorksAsync(Convert.ToInt32(idUser));

            var selectedTasks = userWorksDto.WorkListDto.Tasks
                   .Where(x => x.DateOfWork >= request.StartDate && x.DateOfWork < request.EndDate)
                   .ToList();

            userWorksDto.WorkListDto.Tasks = selectedTasks;

            return userWorksDto;
        }
    }
}
