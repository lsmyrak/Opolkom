using AutoMapper;
using Contracts.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Repositoryes;

namespace WebAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationSetting _authenticationSetting;
        private readonly IPasswordHasher<UserDto> _passwordHasher;
        public AccountService(
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<UserDto> passwordHasher,
            AuthenticationSetting authenticationSetting)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationSetting = authenticationSetting;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            loginDto.Email = loginDto.Email.ToUpper();
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email) ?? throw new BadHttpRequestException("Invalid username or password");
            var userDto = _mapper.Map<UserDto>(user);
            var result = _passwordHasher.VerifyHashedPassword(userDto, userDto.Password, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadHttpRequestException($"Failed to verify {loginDto.Email}");
            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,$"{user.FirstName}  {user.LastName}"),
                new Claim(ClaimTypes.Role, user.UserRole.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSetting.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSetting.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSetting.JwtIssuer,
                _authenticationSetting.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public Task<string> LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterUserDto registerUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task UnregisterAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
