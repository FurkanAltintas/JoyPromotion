using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpContentRepository : DpGenericRepository<Content>, IContentRepository
    {
        public DpContentRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
