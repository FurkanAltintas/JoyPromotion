using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using System.Collections.Generic;

namespace JoyPromotion.Business.Abstract
{
    public interface IUserService
    {
        bool CheckUser(string userName, string password);
        User LoginUser(string userName, string password);
        User FindByName(string userName);

        List<UserListDto> GetAll();
        UserDto GetById(int id);
        UserAddDto Add(UserAddDto userAddDto);
        UserUpdateDto Update(UserUpdateDto userUpdateDto);
        void Delete(User user);
        TDto Convert<TDto>(UserDto userDto);
    }
}
