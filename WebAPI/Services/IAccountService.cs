using Contracts.Dtos.User;

namespace WebAPI.Services
{
    public interface IAccountService
    {
        public Task<string> LoginAsync(LoginDto loginDto);
        public Task<string> LogoutAsync();
        public Task RegisterAsync(RegisterUserDto registerUserDto);
        public Task UnregisterAsync(int id);
    }
}
