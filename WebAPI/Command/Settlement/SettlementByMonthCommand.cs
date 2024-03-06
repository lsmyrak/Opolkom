using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class SettlementByMonthCommand : IRequest
    {
        public int IdUser { get; set; }
        public DateOnly Month { get; set; }

        public SettlementByMonthCommand(int idUser, DateOnly month)
        {
            IdUser = idUser;
            Month = month;
        }
    }

    public class SettlementByMothCommandHandler : IRequestHandler<SettlementByMonthCommand>
    {
        private readonly IWorkService _workService;
        public SettlementByMothCommandHandler(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task Handle(SettlementByMonthCommand request, CancellationToken cancellationToken)
        {
            await _workService.Settlement(request.IdUser, request.Month);
        }
    }
}
