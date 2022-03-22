using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;
using System.Collections.Generic;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool CheckUser(string userName, string password);
        User LoginUser(string userName, string password);
        User FindByName(string userName);
        List<User> GetAllUsersBelongingToTheRole(int roleId);
    }
}
