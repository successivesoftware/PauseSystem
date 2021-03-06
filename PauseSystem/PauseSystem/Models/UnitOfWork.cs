﻿using PauseSystem.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PauseSystem.Models
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Commit();
        void Dispose(bool disposing);
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FrugtContext context;
        
        private bool disposed;

        private Dictionary<string, object> repositories;
        public UnitOfWork(FrugtContext context)
        {
            this.context = context;
        }
        public UnitOfWork()
        {
            this.context = new FrugtContext();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Commit()
        {
            this.context.SaveChanges();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (this.repositories == null)
            {
                this.repositories = new Dictionary<string, object>();
            }
            string name = typeof(TEntity).Name;
            if (!this.repositories.ContainsKey(name))
            {
                Type typeFromHandle = typeof(Repository<>);
                object value = Activator.CreateInstance(typeFromHandle.MakeGenericType(new Type[]
                {
                    typeof(TEntity)
                }), new object[]
                {
                    this.context
                });
                this.repositories.Add(name, value);
            }
            return (IRepository<TEntity>)this.repositories[name];
        }


    }
}