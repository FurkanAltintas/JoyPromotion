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
            return _dbConnection.Query<Content>(@"select co.Id, co.Title, co.SlugTitle, ca.Name as CategoryName,co.Description, co.ImageUrl
            from Contents co
            join Categories ca on
            co.CategoryId = ca.Id
            order by co.Id desc offset 1 rows").ToList();
        }

        public Content TakeTheLast()
        {
            return _dbConnection.QueryFirstOrDefault<Content>(@"select top(1) co.Id, co.CategoryId, ca.Name CategoryName,co.UserId,
            co.Title, co.SlugTitle, co.Description, co.ImageUrl 
            from Contents co
            join Categories ca on
            co.CategoryId = ca.Id
            order by co.Id desc");
        }

        public List<Content> TakeTheLastThree(int id)
        {
            return _dbConnection.Query<Content>(@"select top(3)
            co.Id, co.Title, co.SlugTitle, co.Description, co.ImageUrl from Contents as co 
            where co.Id != @id order by co.Id desc", new
            {
                @id = id
            }).ToList();
        }
    }
}
