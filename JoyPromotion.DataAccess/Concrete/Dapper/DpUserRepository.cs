using Dapper;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;
using System.Linq;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpUserRepository : DpGenericRepository<User>, IUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpUserRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public bool CheckUser(string userName, string password)
        {
            var user = _dbConnection.Query("select * from Users where UserName=@userName and Password=@password", new
            {
                userName = userName,
                password = password
            }).FirstOrDefault();

            return user != null;
        }

        public User FindByName(string userName)
        {
            return _dbConnection.QueryFirstOrDefault<User>("select * from Users where UserName=@userName", new
            {
                userName = userName
            });
        }

        public User LoginUser(string userName, string password)
        {
            return _dbConnection.QueryFirstOrDefault<User>("select * from Users where UserName=@userName and Password=@password", new
            {
                userName = userName,
                password = password
            });
        }
    }
}
