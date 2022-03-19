using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Shared.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}
