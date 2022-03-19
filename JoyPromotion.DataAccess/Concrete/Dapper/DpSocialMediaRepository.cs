using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Data;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpSocialMediaRepository : DpGenericRepository<SocialMedia>, ISocialMediaRepository
    {
        public DpSocialMediaRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
