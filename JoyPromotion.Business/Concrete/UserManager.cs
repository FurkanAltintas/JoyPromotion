using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
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

        public User FindByName(string userName)
        {
            return _userRepository.FindByName(userName);
        }

        public List<UserListDto> GetAll()
        {
            return _mapper.Map<List<UserListDto>>(_userRepository.GetAll());
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetById(id));
        }

        public User LoginUser(string userName, string password)
        {
            return _userRepository.LoginUser(userName, password);
        }

        public UserUpdateDto Update(UserUpdateDto userUpdateDto)
        {
            var updatedUser = _mapper.Map<User>(userUpdateDto);
            _userRepository.Update(updatedUser);
            return userUpdateDto;
        }
    }
}
