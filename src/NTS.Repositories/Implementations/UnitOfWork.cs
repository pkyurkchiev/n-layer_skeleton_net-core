namespace NTS.Repositories.Implementations
{
    using Data.Entities;
    using Data.Entities.Interfaces;
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        #endregion

        #region Constructors

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        #endregion

        #region Methods

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        #endregion

        #region Private Methods

        private IRepository<T> GetRepository<T>() where T : Entity, IIsActive
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        #endregion
    }

}
