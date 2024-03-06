using Contracts.Dtos.Task;
using Contracts.Dtos.User;

namespace WebAPI.Services
{
    public interface IUserService
    {
        //Gets ..
        public Task<IEnumerable<UserDto>> GetUsersDtoAsync();

        public Task<UserDto> GetUserDto(int id);

        public Task<UserWorkDto> GetUserDtoWithWorksAsync(int id);

        public Task<IEnumerable<UserWorkDto>> GetUsersWithWorksAsync();

        //Add Work
        public Task AddWorkToUser(WorkDto workDto);

        //Delete Work 
        public Task DeleteWork(int idWork);

        //Update Work

        public Task UpdateWork(WorkDto workDto);
    }
}
