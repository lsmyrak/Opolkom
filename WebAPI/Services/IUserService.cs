using Contracts.Dtos.User;

namespace WebAPI.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetUsersDtoAsync();
    }
}
