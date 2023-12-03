using AutoMapper;
using Contracts.Dtos.User;
using Domain.Model;
using WebAPI.Repositoryes;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepository userRepository
            ,IMapper mapper)
        {
            _mapper = mapper;
            _repository = userRepository;            
        }
        public async Task<IEnumerable<UserDto>> GetUsersDtoAsync()
        {
            var users = await _repository.GetUserAsync();
            return users.Select(x => _mapper.Map<UserDto>(x));            
        }
    }
}
