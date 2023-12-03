using Contracts.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Queries;

namespace WebAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-users")]
        public Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mediator.Send(new GetUsersQuery());
        }
    }
}
