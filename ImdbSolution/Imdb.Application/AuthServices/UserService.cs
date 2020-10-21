﻿using System.Security.Claims;
using AutoMapper;
using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Entities;
using IronFit.Domain.AuthAggregate.Repositories;
using IronFit.Domain.AuthAggregate.Services;
using IronFit.Domain.Properties;
using IronFit.Domain.Shared.Exceptions;
using IronFit.Domain.Shared.Filters;
using IronFit.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace IronFit.Application.AuthServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(IMapper mapper, 
            IUserRepository userRepository, 
            IUnityOfWork unityOfWork, 
            IAuthService authService, 
            IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _unityOfWork = unityOfWork;
            _authService = authService;
            _httpContext = httpContext;
        }

        public void RegisterAdmin(AdminForRegisterDto adminForRegisterDto)
        {
            var admin = _mapper.Map<User>(adminForRegisterDto);

            admin.PasswordHash = _authService.GeneratePasswordHash(adminForRegisterDto.Password);

            _userRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            var admin = _mapper.Map<User>(userForRegisterDto);

            admin.PasswordHash = _authService.GeneratePasswordHash(userForRegisterDto.Password);

            _userRepository.Create(admin);

            _unityOfWork.Commit();
        }

        public void UpdateUser(UserForUpdateDto userForUpdateDto)
        {
            var userId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (userId != userForUpdateDto.Id) throw new CoreException(Resources.EditarSemPermissao);

            var user = _userRepository.GetById(userId);

            user.Name = userForUpdateDto.Name;

            _userRepository.Update(user);

            _unityOfWork.Commit();
        }

        public void InactivateUserAsAdmin(int idUser)
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userInacvating = _userRepository.GetById(idToken);

            if (!userInacvating.Admin) throw new CoreException(Resources.InativarSemPermissao);

            var userToInactivate = new User {Id = idUser, Active = false};

            _userRepository.Inactivate(userToInactivate);

            _unityOfWork.Commit();
        }

        public void InactivateUser()
        {
            var idToken = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var userToInactivate = new User { Id = idToken, Active = false };

            _userRepository.Inactivate(userToInactivate);

            _unityOfWork.Commit();
        }

        public GenericFilter<UsersForList> GetUsers(GenericFilter<UsersForList> filter)
        {
            var result = _userRepository.GetUsers(filter);

            return result;
        }
    }
}
