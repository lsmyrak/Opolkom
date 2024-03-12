using Contracts.Dtos.Task;
using Contracts.Dtos.User;

namespace WebAPI.Services
{
    public interface IUserService
    {
        //Gets ..
        public Task<IEnumerable<UserDto>> GetUsersDtoAsync();
        public Task<IEnumerable<UserWorkDto>> GetUsersWithWorksAsync();

        public Task<UserDto> GetUserDtoAsync(int id);

        public Task<UserWorkDto> GetUserDtoWithWorksAsync(int id);


        //Add Work
        public Task AddWorkToUser(WorkDto workDto);

        //Delete Work 
        public Task DeleteWork(int idWork);

        //Update Work

        public Task UpdateWork(WorkDto workDto);
    }
}
