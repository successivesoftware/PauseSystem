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

    public class Repository<TEntity> where TEntity : BaseEntity
    {
        private readonly FrugtContext context;
        private DbSet<TEntity> dbSet;
        private string errorMessage = string.Empty;
        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return this.dbSet;
            }
        }
        public Repository(FrugtContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public TEntity GetById(object id)
        {
            return this.dbSet.Find(new object[]
			{
				id
			});
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> queryable = this.dbSet;
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }
            string[] array = includeProperties.Split(new char[]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i];
                queryable = QueryableExtensions.Include<TEntity>(queryable, text);
            }
            IEnumerable<TEntity> result;
            if (orderBy != null)
            {
                result = orderBy(queryable).ToList<TEntity>();
            }
            else
            {
                result = queryable.ToList<TEntity>();
            }
            return result;
        }
        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return this.dbSet.SqlQuery(query, parameters).ToList<TEntity>();
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


}