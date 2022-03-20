using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpContentTagRepository : DpGenericRepository<ContentTag>, IContentTagRepository
    {
        public DpContentTagRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
