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
        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.Include(r=>r.UserRole).Where(x=>x.IsActive).ToListAsync();
        }
    }
}
