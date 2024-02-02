
using Domain.Model;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositoryes
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.SingleOrDefaultAsync(x => x.Name.Equals(roleName));
        }
    }
}
