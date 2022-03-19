using Dapper;
using Dapper.Contrib.Extensions;
using JoyPromotion.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace JoyPromotion.Shared.DataAccess.Dapper
{
    public class DpGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IDbConnection _dbConnection;

        public DpGenericRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public TEntity Add(TEntity entity)
        {
            _dbConnection.Insert(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _dbConnection.Delete(entity);
            return entity;
        }

        public List<TEntity> GetAll()
        {
            return _dbConnection.GetAll<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbConnection.Get<TEntity>(id);
        }

        public TEntity Update(TEntity entity)
        {
            _dbConnection.Update(entity);
            return entity;
        }
    }
}
