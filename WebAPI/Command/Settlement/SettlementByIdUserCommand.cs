using MediatR;
using WebAPI.Services;

namespace WebAPI.Command
{
    public class SettlementByIdUserCommand:IRequest
    {
        public int IdUser { get; set; }
        public SettlementByIdUserCommand(int idUser)
        {
            IdUser = idUser;
        }
    }

    public class SettlementByIdUserCommandHandler : IRequestHandler<SettlementByIdUserCommand>
    {
        private readonly IWorkService _woService;
        public SettlementByIdUserCommandHandler(IWorkService workService)
        {
            _woService = workService;
        }
        public async Task Handle(SettlementByIdUserCommand request, CancellationToken cancellationToken)
        {
            await _woService.SettlementByUser(request.IdUser);
        }
    }
}
