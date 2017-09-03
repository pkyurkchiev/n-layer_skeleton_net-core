namespace NTS.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class NTSContext : DbContext
    {
        public NTSContext(DbContextOptions<NTSContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
