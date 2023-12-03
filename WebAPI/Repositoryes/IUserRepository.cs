using Domain.Model;

namespace WebAPI.Repositoryes
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUserAsync();
    }
}
