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
            optionsBuilder.UseSqlServer(@"Server=tcp:127.0.0.1,5433;Database=N-TierSkeleton;User Id=sa;Password=Pass@word;Encrypt=false;");//@"Data Source=.\SQLEXPRESS;Initial Catalog=N-TierSkeleton;Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
        }
    }
}
