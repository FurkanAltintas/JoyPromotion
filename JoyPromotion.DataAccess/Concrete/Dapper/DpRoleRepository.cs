using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpRoleRepository : DpGenericRepository<Role>, IRoleRepository
    {
        public DpRoleRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
