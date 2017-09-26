namespace NTS.Repositories.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IUserRepository Users { get; }

        int SaveChanges();

    }
}
