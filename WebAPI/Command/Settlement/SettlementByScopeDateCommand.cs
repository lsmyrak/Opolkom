using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class SettlementByScopeDateCommand:IRequest
    {
        public int IdUser { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set;}

        public SettlementByScopeDateCommand(int  idUser,DateOnly startDate,DateOnly endDate)
        {
            IdUser = idUser;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    public class SettlementByScopeDateCommandHandler : IRequestHandler<SettlementByScopeDateCommand>
    {
        private readonly IWorkService _workService;
        public SettlementByScopeDateCommandHandler(IWorkService workService)
        {
            _workService = workService;
        }
        public async Task Handle(SettlementByScopeDateCommand request, CancellationToken cancellationToken)
        {
            await _workService.SettlementAsync(request.IdUser,request.StartDate,request.EndDate);
        }
    }
}
