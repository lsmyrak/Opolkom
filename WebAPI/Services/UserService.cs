﻿using AutoMapper;
using Contracts.Dtos.Task;
using Contracts.Dtos.User;
using Domain.Model;
using Domain.Model.Enums;
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

        public async Task<UserDto> GetUserDtoAsync(int id)
        {
            var user = await _userRepository.GetUserWithWorkAsync(id);
            return _mapper.Map<UserDto>(user);

        }

        public async Task<UserWorkDto> GetUserDtoWithWorksAsync(int id)
        {
            var user = await _userRepository.GetUserWithWorkAsync(id);
            var userTaskDto = _mapper.Map<UserWorkDto>(user);
            userTaskDto.WorkListDto.Calc();
            return userTaskDto;
        }

        public async Task<IEnumerable<UserWorkDto>> GetUsersWithWorksAsync()
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
            var userId = Convert.ToInt32((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

            var user = await _userRepository.GetUserWithWorkAsync(userId);
            var work = _mapper.Map<Work>(workDto);
            user.AddWork(work);
            await _userRepository.UpdateDataUser(user);
        }

        public async Task DeleteWork(int idWork)
        {

            var role = ((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value));
            if (role.Equals(Roles.Admin.ToString()))
            {
                var u = await _userRepository.GetUsersWithWorkAsync();
                var userUpdates = u.FirstOrDefault(x => x.Works.Any(c => c.Id == idWork));
                if (userUpdates != null)
                {
                    userUpdates.RemoveWork(userUpdates.Works.FirstOrDefault(x => x.Id == idWork));
                    await _userRepository.UpdateDataUser(userUpdates);
                }
            }
            else
            {
                var userId = Convert.ToInt32((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

                var user = await (_userRepository.GetUserWithWorkAsync(userId));
                if (user != null)
                {
                    user.RemoveWork(user.Works.FirstOrDefault(x => x.Id == idWork));
                    await _userRepository.UpdateDataUser(user);
                }
            }
        }

        public async Task UpdateWork(WorkDto workDto)
        {
            var userRole = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            if (userRole != null && userRole.Equals(Roles.Admin))
            {
                var u = await _userRepository.GetUsersWithWorkAsync();
                if (u != null)
                {
                    var userUpdates = u.FirstOrDefault(x => x.Works.Any(c => c.Id == workDto.Id));
                    if (userUpdates != null)
                    {
                        var work = _mapper.Map<Work>(workDto);
                        userUpdates.UpdateWork(work);
                        await _userRepository.UpdateDataUser(userUpdates);

                    }
                }
            }
            else
            {
                var userId = Convert.ToInt32((_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));

                var user = await (_userRepository.GetUserWithWorkAsync(userId));
                if (user != null)
                {
                    var work = _mapper.Map<Work>(workDto);
                    user.UpdateWork(work);
                    await _userRepository.UpdateDataUser(user);
                }
            }
        }
    }
}
