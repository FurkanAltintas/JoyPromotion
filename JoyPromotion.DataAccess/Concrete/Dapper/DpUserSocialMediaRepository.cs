using Dapper;
using JoyPromotion.DataAccess.Abstract;
using JoyPromotion.Dtos.Dtos;
using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JoyPromotion.DataAccess.Concrete.Dapper
{
    public class DpUserSocialMediaRepository : DpGenericRepository<UserSocialMedia>, IUserSocialMediaRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpUserSocialMediaRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // List<T> GetUserSocialMedia<T>(int userId) where T : class, new(); | (INTERFACE)
        // public List<T> GetUserSocialMedia<T>(int userId) where T : class, IDto, new() | CLASS
        public List<UserSocialMediaListDto> GetUserSocialMedia(int userId)
        {
            return _dbConnection.Query<UserSocialMediaListDto>(@"select usm.Id, usm.SocialMediaId, sm.Name, sm.Icon,usm.Url 
            from UserSocialMedias usm join SocialMedias sm on usm.SocialMediaId = sm.Id where usm.UserId = @userId",
            new
            {
                @userId = userId
            }).ToList();
        }
    }
}
