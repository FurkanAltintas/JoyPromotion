using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpContactRepository : DpGenericRepository<Contact>, IContactRepository
    {
        public DpContactRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
