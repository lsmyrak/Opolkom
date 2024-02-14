using Domain.Model;

namespace WebAPI.Repositoryes
{
    public interface IUserRepository
    {
        // Gets..
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<IEnumerable<User>> GetUsersWithWorkAsync();
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserWithWorkAsync(int id);

        public Task<User> GetUserById(int id);

        //Delete
        public Task<User> DeleteUserAsync(int id);

        //Update
        public Task UpdateDataUser(User user);

        //Create
        public Task CreateUserAsync(User user);

    }
}
