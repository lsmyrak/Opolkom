﻿
using AutoMapper;
using WebAPI.Repositoryes;

namespace WebAPI.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUserRepository _userRepository;
        public WorkService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SettlementAsync(int idUser, int IdWork)
        {
            var user = await _userRepository.GetUserAsync(idUser);
            if (user != null)
            {
                user.Settlement(IdWork);
                await _userRepository.UpdateDataUser(user);
            }
        }

        public async Task SettlementAsync(int idUser, DateOnly month)
        {
            var user = await _userRepository.GetUserAsync(idUser);
            if (user != null)
            {
                foreach (var work in user.Works.Where(c => c.DateOfWork.Month == month.Month))
                {
                    user.Settlement(work.Id);
                    await _userRepository.UpdateDataUser(user);
                }
            }
        }

        public async Task SettlementAsync(int IdUser, DateOnly startDate, DateOnly stopDate)
        {
            var user = await _userRepository.GetUserWithWorkAsync(IdUser);
            var works = user.Works.Where(x => x.DateOfWork >= startDate && x.DateOfWork < stopDate);
            foreach (var work in works)
            { 
                user.Settlement(work.Id);
            }
            await _userRepository.UpdateDataUser(user);
        }

        public async Task SettlementAsync(int IdUser)
        {
            var user = await _userRepository.GetUserAsync(IdUser);
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
