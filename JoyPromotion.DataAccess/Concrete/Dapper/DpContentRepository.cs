using Dapper;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpContentRepository : DpGenericRepository<Content>, IContentRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpContentRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Content> GetAllOrderBy()
        {
            return _dbConnection.Query<Content>("select * from Contents order by Id desc offset 1 rows").ToList();
        }

        public Content TakeTheLast()
        {
            return _dbConnection.QueryFirstOrDefault<Content>("select top(1) * from Contents order by Id desc");
        }
    }
}
