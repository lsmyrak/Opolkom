using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class SettlementByIdWorkCommand : IRequest
    {
        public int IdWork { get; set; }
        public int IdUser { get; set; }
        public SettlementByIdWorkCommand(int idWork, int idUser)
        {
            IdWork = idWork;
            IdUser = idUser;
        }
    }

    public class SettlementByIdWorkCommandHandler : IRequestHandler<SettlementByIdWorkCommand>
    {
        private readonly IWorkService _workService;
        public SettlementByIdWorkCommandHandler(IWorkService workService)
        {
            _workService = workService;
        }
        public async Task Handle(SettlementByIdWorkCommand request, CancellationToken cancellationToken)
        {
            await _workService.SettlementAsync(request.IdUser, request.IdWork);
        }
    }
}
