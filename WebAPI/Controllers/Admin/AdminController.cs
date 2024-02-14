using Contracts.Dtos.Task;
using Contracts.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Command;
using WebAPI.Queries;

namespace WebAPI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("unregister/{idUser}")]
        public async Task Unregister(int idUser)
        {
            await _mediator.Send(new UnregisterCommand(idUser));
        }

        [HttpGet("get-users")]
        public Task<IEnumerable<UserDto>> GetUsers()
        {
            return _mediator.Send(new GetUsersQuery());
        }

        [HttpGet("get-user/{id}")]
        public async Task<UserDto> GetUserById(int id)
        {
            return await _mediator.Send(new GetUserQuery(id));
        }

        [HttpGet("get-user-with-task/{idUser}")]
        public async Task<UserWorkDto> GetUserTask(int idUser)
        {
            return await _mediator.Send(new GetUserTasksById(idUser));
        }

        [HttpGet("get-users-with-task")]
        public async Task<IEnumerable<UserWorkDto>> GetUsersWorkDtosAsync()
        {
            return await _mediator.Send(new GetUsersTaskQuery());
        }

        [HttpPatch("/edit-task")]
        public async Task EditTaskUser(WorkDto workdto)
        {
            await _mediator.Send(new UpdateTaskCommand(workdto));
        }

        [HttpDelete("/delete-task/{idTask}")]
        public async Task DeleteTask(int idTask)
        {
            await _mediator.Send(new DeleteTaskCommand(idTask));
        }

        /*
             //[HttpPost("settled-by-user/{idUser}")]
             rozlicz by user (calosc)
             rozlicz by zadanie
             rozlicz by miesiac
              */

    }
}
