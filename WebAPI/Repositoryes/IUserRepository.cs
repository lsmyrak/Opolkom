using Domain.Model;

namespace WebAPI.Repositoryes
{
    public interface IUserRepository
    {
        // Gets..
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<IEnumerable<User>> GetUsersWithWorkAsync();
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserAsync(int id);
        
        //Delete
        public Task<User> DeleteUserAsync(int id);

        //Create

        //Update
        public Task UpdateUserAsync(User user);
    }
}
