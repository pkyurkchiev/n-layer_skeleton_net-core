namespace NTS.Repositories.Implementations
{
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}
