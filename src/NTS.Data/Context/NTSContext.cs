namespace NTS.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class NTSContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public NTSContext() : base() { }
        //public NTSContext(DbContextOptions<NTSContext> options)
        //    : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=MyDW; Persist Security Info = False; User ID = TempUser; Password = Temp123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
