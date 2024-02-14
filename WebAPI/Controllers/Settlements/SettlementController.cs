using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Command;

namespace WebAPI.Controllers.Settlements
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SettlementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("by-idWork")]
        public async Task Settlemnet(int idWork, int idUser)
        {
            await _mediator.Send(new SettlementByIdWorkCommand(idWork, idUser));
        }

        [HttpPatch("by-date")]
        public async Task Settlemnet(int idUser, DateOnly startDate, DateOnly stopDate)
        {
            throw new NotImplementedException("haha");
        }

        [HttpPatch("by-month")]
        public async Task Settlemnet(int idUser, DateOnly month)
        {
            await _mediator.Send(new SettlementByMonthCommand(idUser, month));
        }
    }
}
