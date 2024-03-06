namespace WebAPI.Services
{
    public interface IWorkService
    {
        public Task Settlement(int IdUser);
        public Task Settlement(int idUser, int IdWork);
        public Task Settlement(int IdUser, DateOnly startDate, DateOnly stopDate);
        public Task Settlement(int idUser, DateOnly month);
    }
}
