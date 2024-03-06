
using AutoMapper;
using WebAPI.Repositoryes;

namespace WebAPI.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public WorkService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task Settlement(int idUser, int IdWork)
        {
            var user = await _userRepository.GetUserById(idUser);
            if (user != null)
            {
                user.Settlement(IdWork);
                await _userRepository.UpdateDataUser(user);
            }
        }

        public async Task Settlement(int idUser, DateOnly month)
        {
            var user = await _userRepository.GetUserById(idUser);
            if (user != null)
            {
                foreach (var work in user.Works.Where(c => c.DateOfWork.Month == month.Month))
                {
                    user.Settlement(work.Id);
                    await _userRepository.UpdateDataUser(user);
                }
            }
        }

        public Task Settlement(int IdUser, DateOnly startDate, DateOnly stopDate)
        {
            throw new NotImplementedException();
        }

        public async Task Settlement(int IdUser)
        {
            var user = await _userRepository.GetUserById(IdUser);
            if (user != null) 
            {
                foreach(var work in user.Works) 
                {
                    user.Settlement(work.Id);
                }
                await _userRepository.UpdateDataUser(user);
            }
        }
    }
}
