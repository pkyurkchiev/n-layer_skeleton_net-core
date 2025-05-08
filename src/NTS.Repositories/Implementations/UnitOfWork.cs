namespace NTS.Repositories.Implementations
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private readonly DbContext context;

        #endregion

        #region Constructors

        public UnitOfWork(DbContext context)
        {
            this.context = context;

            Users = new UserRepository(context);
            Roles = new RoleRepository(context);
        }

        #endregion

        #region Methods

        public IRoleRepository Roles { get; private set; }

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
                this.context?.Dispose();
            }
        }
        #endregion
    }

}
