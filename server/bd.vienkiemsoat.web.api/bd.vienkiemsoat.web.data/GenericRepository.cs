using bd.vienkiemsoat.web.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using bd.vienkiemsoat.web.data.Interfaces;
using System.Data.Entity;

namespace bd.vienkiemsoat.web.data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbEntities;
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbEntities = dbContext.Set<TEntity>();
            _dbContext = dbContext;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, object>>[] includes = null, Expression<Func<TEntity, object>> sortOrderBy = null, bool sortDecs = false)
        {
            IQueryable<TEntity> result = _dbEntities.AsNoTracking().AsQueryable();
            if (filter != null)
            {
                result = _dbEntities.Where(filter);
            }

            if (includes != null)
            {
                foreach (var inclue in includes)
                {
                    result = result.Include(inclue);
                }

            }

            if (sortOrderBy != null)
            {
                if (sortDecs)
                {
                    result = result.OrderByDescending(sortOrderBy);
                }
                else
                {
                    result = result.OrderBy(sortOrderBy);
                }
            }

            return result.ToList();
        }

        public TEntity GetById(Guid id, params string[] includes)
        {
            var entity = _dbEntities.Where(x => x.Id == id);
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }

            }
            return entity.SingleOrDefault();
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            var entityOgirinal = GetById(entity.Id);
            if (entityOgirinal == null)
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                    entity.NgayTaoRecord = DateTime.Now;
                }
                _dbEntities.Add(entity);
                return entity;
            }
            else
            {
                _dbContext.Entry(entityOgirinal).CurrentValues.SetValues(entity);
            }


            return entity;

        }

        public void AddRange(TEntity[] entities)
        {
            _dbEntities.AddRange(entities);
        }

        public void Delete(Guid id)
        {
            var entityOgirinal = GetById(id);
            _dbContext.Entry(entityOgirinal).State = EntityState.Deleted;

        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Delete(Expression<Func<TEntity, bool>> delete)
        {
            var entities = _dbEntities.Where(delete);
            _dbEntities.RemoveRange(entities);
        }
    }
}
