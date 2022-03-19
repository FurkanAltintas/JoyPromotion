using JoyPromotion.Entities.Concrete;
using JoyPromotion.Shared.DataAccess;
using System.Collections.Generic;

namespace JoyPromotion.DataAccess.Abstract
{
    public interface IContentRepository : IGenericRepository<Content>
    {
        List<Content> GetAllOrderBy();
        Content TakeTheLast();
    }
}
