using Domain.Model;

namespace WebAPI.Repositoryes
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleByNameAsync(string roleName);
    }
}
