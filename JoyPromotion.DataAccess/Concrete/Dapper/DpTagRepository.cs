using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpTagRepository : DpGenericRepository<Tag>, ITagRepository
    {
        public DpTagRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
