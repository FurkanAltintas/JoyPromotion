using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool CheckUser(string userName, string password);
        User FindByName(string userName);
    }
}
