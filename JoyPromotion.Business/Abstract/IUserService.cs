using JoyPromotion.Entities.Concrete;

namespace JoyPromotion.Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        bool CheckUser(string userName, string password);
        User LoginUser(string userName, string password);
        User FindByName(string userName);
    }
}
