namespace NTS.Repositories.Interfaces
{
    using System;
    using Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        int SaveChanges();

    }
}
