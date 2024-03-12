using Domain.Model;

namespace WebAPI.Repositoryes
{
    public interface IRoleRepository
    {
        public Task<Role> GetRole(string roleName);
    }
}
