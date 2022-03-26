using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpCategoryRepository : DpGenericRepository<Category>, ICategoryRepository
    {
        public DpCategoryRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
