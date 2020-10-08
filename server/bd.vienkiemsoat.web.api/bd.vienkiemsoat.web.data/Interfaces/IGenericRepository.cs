using bd.vienkiemsoat.web.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace bd.vienkiemsoat.web.data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, object>> sortOrderBy = null, bool sortDecs = false);
        TEntity GetById(Guid id, params string[] includes);
        TEntity SaveOrUpdate(TEntity entity);
        void AddRange(TEntity[] entities);
        void Delete(Guid id);
        void Delete(Expression<Func<TEntity, bool>> delete);
        void Save();        
    }
}
