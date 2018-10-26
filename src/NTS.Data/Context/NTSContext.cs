namespace NTS.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class NTSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public NTSContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=100.104.136.140,1400;initial catalog=N-TierSkeleton;User ID=SA;Password=!Passw0rd;");//@"Data Source=.\SQLEXPRESS;Initial Catalog=N-TierSkeleton;Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
