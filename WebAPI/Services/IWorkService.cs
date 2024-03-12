namespace WebAPI.Services
{
    public interface IWorkService
    {
        public Task SettlementAsync(int IdUser);
        public Task SettlementAsync(int idUser, int IdWork);
        public Task SettlementAsync(int IdUser, DateOnly startDate, DateOnly stopDate);
        public Task SettlementAsync(int idUser, DateOnly month);
    }
}
