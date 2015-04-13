using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PauseSystem.Models
{

    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> AsQuerable();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entity);
       // IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               List<Expression<Func<TEntity, object>>> includeProperties = null, int? page = null, int? pageSize = null);

    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly FrugtContext context;
        private DbSet<TEntity> dbSet;
        private string errorMessage = string.Empty;
       

        public Repository(FrugtContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQuerable()
        {
            return this.dbSet;
        }
        public TEntity GetById(object id)
        {
            return this.dbSet.Find(new object[]
            {
                id
            });
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.dbSet.Add(entity);
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.dbSet.Remove(entity);
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                var entity = dbSet.Find(id);
                if (entity != null)
                    this.dbSet.Remove(entity);
            }
            catch (DbEntityValidationException ex)
            {
                HandleValidationException(ex);
            }
        }


        //public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        //{
        //    IQueryable<TEntity> queryable = this.dbSet;
        //    if (filter != null)
        //    {
        //        queryable = queryable.Where(filter);
        //    }
        //    string[] array = includeProperties.Split(new char[]
        //    {
        //        ','
        //    }, StringSplitOptions.RemoveEmptyEntries);
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        string text = array[i];
        //        queryable = QueryableExtensions.Include<TEntity>(queryable, text);
        //    }
        //    IEnumerable<TEntity> result;
        //    if (orderBy != null)
        //    {
        //        result = orderBy(queryable).ToList<TEntity>();
        //    }
        //    else
        //    {
        //        result = queryable.ToList<TEntity>();
        //    }
        //    return result;
        //}
        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters).ToList<TEntity>();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               List<Expression<Func<TEntity, object>>> includeProperties = null, int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null)
                includeProperties.ForEach(i => { query = query.Include(i); });

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query
                    .Skip((page.Value - 1) * pageSize.Value)
                    .Take(pageSize.Value);

            return query;
        }

        private void HandleValidationException(DbEntityValidationException ex)
        {
            foreach (DbEntityValidationResult current in ex.EntityValidationErrors)
            {
                foreach (DbValidationError current2 in current.ValidationErrors)
                {
                    this.errorMessage = this.errorMessage + string.Format("Property: {0} Error: {1}", current2.PropertyName, current2.ErrorMessage) + Environment.NewLine;
                }
            }
            throw new Exception(this.errorMessage, ex);
        }


    }


}