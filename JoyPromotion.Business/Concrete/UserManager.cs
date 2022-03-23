using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.Utils;
using System;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserAddDto Add(UserAddDto userAddDto)
        {
            var addedUser = _mapper.Map<User>(userAddDto);
            #region FirstName & SurName = UserName
            string fullName = string.Format(addedUser.FirstName + addedUser.SurName);
            string tag = Guid.NewGuid().ToString().Substring(0, 4);
            addedUser.UserName = UserNameExtensions.UserName(fullName) + tag;
            #endregion
            _userRepository.Add(addedUser);
            return userAddDto;
        }

        public bool CheckUser(string userName, string password)
        {
            return _userRepository.CheckUser(userName, password);
        }

        public TDto Convert<TDto>(UserDto userDto)
        {
            return _mapper.Map<TDto>(userDto);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public UserDto FindByName(string userName)
        {
            return _mapper.Map<UserDto>(_userRepository.FindByName(userName));
        }

        public List<UserListDto> GetAll()
        {
            return _mapper.Map<List<UserListDto>>(_userRepository.GetAll());
        }

        public List<UserListDto> GetAllUsersBelongingToTheRole(int roleId)
        {
            return _mapper.Map<List<UserListDto>>(_userRepository.GetAllUsersBelongingToTheRole(roleId));
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetById(id));
        }

        public User LoginUser(string userName, string password)
        {
            return _userRepository.LoginUser(userName, password);
        }

        public void PaswordUpdate(string password, int userId)
        {
            var user = _userRepository.GetById(userId);
            user.Password = password;
            _userRepository.Update(user);
        }

        public UserUpdateDto Update(UserUpdateDto userUpdateDto)
        {
            var updatedUser = _mapper.Map<User>(userUpdateDto);
            _userRepository.Update(updatedUser);
            return userUpdateDto;
        }
    }
}
