using Domain.Model;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositoryes
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Include(r => r.UserRole).Where(x => x.IsActive).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Include(r => r.UserRole).SingleOrDefaultAsync(x => x.Email.Equals(email) && x.IsActive);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> GetUserWithWorkAsync(int id)
        {
            return await _context.Users.Include(r => r.UserRole).Include(w => w.Works.Where(a => a.IsActive)).Where(x => x.IsActive).SingleAsync(x => x.Id == id);
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var user = await _context.Users.SingleAsync(x => x.Id == id);
            if (user == null)
            {
                //Todo:
                throw new BadHttpRequestException("User not esist");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersWithWorkAsync()
        {
            return await _context.Users.Include(w => w.Works.Where(a => a.IsActive)).Where(x => x.IsActive).ToListAsync();
        }

        public async Task UpdateDataUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
