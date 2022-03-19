using JoyPromotion.Business.Abstract;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;

namespace JoyPromotion.Business.Concrete
{
    public class UserManager : GenericManager<User>, IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IUserRepository _userRepository;
        public UserManager(IGenericRepository<User> genericRepository, IUserRepository userRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
            _userRepository = userRepository;
        }

        public bool CheckUser(string userName, string password)
        {
            _userRepository.CheckUser(userName, password);
        }
    }
}
