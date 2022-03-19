using AutoMapper;
using JoyPromotion.Business.Abstract;
using JoyPromotion.Shared.DataAccess;
using JoyPromotion.Shared.Entities;
using System.Collections.Generic;

namespace JoyPromotion.Business.Concrete
{
    public class GenericManagerDto<TEntity, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityDeleteDto> : IGenericServiceDto<TEntity, TEntityDto, TEntityAddDto, TEntityUpdateDto, TEntityDeleteDto> where TEntity : class, IEntity, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper _mapper;

        public GenericManagerDto(IGenericRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public TEntityAddDto Add(TEntityAddDto entity)
        {
            var entityAdded = _mapper.Map<TEntity>(entity);
            _genericRepository.Add(entityAdded);
            return entity;
        }

        public TEntityDeleteDto Delete(TEntityDeleteDto entity)
        {
            var entityDeleted = _mapper.Map<TEntity>(entity);
            _genericRepository.Delete(entityDeleted);
            return entity;

        }

        public List<TEntityDto> GetAll()
        {
            return _mapper.Map<List<TEntityDto>>(_genericRepository.GetAll());
        }

        public TEntity GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public TEntityUpdateDto Update(TEntityUpdateDto entity)
        {
            var entityUpdated = _mapper.Map<TEntity>(entity);
            _genericRepository.Update(entityUpdated);
            return entity;
        }
    }
}
