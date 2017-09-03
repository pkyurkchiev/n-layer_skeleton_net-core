namespace NTS.Repositories.Implementations
{
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }

}
