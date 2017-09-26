namespace NTS.Repositories.Implementations
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

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

            Users = new UserRepository(context);
        }

        #endregion

        #region Methods

        public IUserRepository Users { get; private set; }

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
    }

}
