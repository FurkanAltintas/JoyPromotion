using JoyPromotion.Business.Abstract;
using JoyPromotion.Shared.DataAccess;
using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericManager(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public TEntity Add(TEntity entity)
        {
            _genericRepository.Add(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _genericRepository.Delete(entity);
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public TEntity Update(TEntity entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
