using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;
using System.Collections.Generic;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IContentTagRepository : IGenericRepository<ContentTag>
    {
        List<T> FetchTagsOfContent<T>(int contentId);
    }
}
