using AutoMapper;
using Contracts.Dtos.Task;
using Contracts.Dtos.User;
using Domain.Model;
using System.Security.Claims;
using WebAPI.Repositoryes;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public UserService(
            IUserRepository userRepository, 
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UserDto>> GetUsersDtoAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Select(x => _mapper.Map<UserDto>(x));
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return _mapper.Map<UserDto>(user);

        }

        public async Task<UserWorkDto> GetUserTasksByIdAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            var userTaskDto = _mapper.Map<UserWorkDto>(user);
            userTaskDto.WorkListDto.Calc();
            return userTaskDto;
        }

        public async Task<IEnumerable<UserWorkDto>> GetUsersWorksAsync()
        {
            var users = await _userRepository.GetUsersWithWorkAsync();
            var usersTaskDto = users.Select(x => _mapper.Map<UserWorkDto>(x));
            List<UserWorkDto> usersWorkCalc = new List<UserWorkDto>();
            foreach (var userwork in usersTaskDto)
            {
                userwork.WorkListDto.Calc();
                usersWorkCalc.Add(userwork);
            }
            return usersWorkCalc;
        }

        public async Task AddWorkToUser(WorkDto workDto)
        {
            var  userId = Convert.ToInt32((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)); 

            var user = await _userRepository.GetUserAsync(userId);
            var work = _mapper.Map<Work>(workDto);
            user.AddWork(work);
            await _userRepository.UpdateUserAsync(user);
        }
    }
}
