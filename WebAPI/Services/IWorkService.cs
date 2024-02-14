namespace WebAPI.Services
{
    public interface IWorkService
    {
        public Task SettlementByUser(int IdUser);
        public Task SettlementByIdWork(int idUser, int IdWork);
        public Task SettlementByScopeDate(int IdUser, DateOnly startDate, DateOnly stopDate);
        public Task SettlementbyMonth(int idUser, DateOnly month);
    }
}
