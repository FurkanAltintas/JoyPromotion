using Dapper;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpContentTagRepository : DpGenericRepository<ContentTag>, IContentTagRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpContentTagRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<T> FetchTagsOfContent<T>(int contentId)
        {
            return _dbConnection.Query<T>(@"select t.Id, t.Name from ContentTags ct
                                  join Tags t on
                                  t.Id = ct.TagId
                                  where ct.ContentId = @contentId", new
            {
                                    contentId = contentId
            }).ToList();
        }
    }
}
