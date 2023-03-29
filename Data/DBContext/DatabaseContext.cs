using ApplicationMember.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMember.Data.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<DataModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //NpgSQL Dateadjustment
            modelBuilder.Entity<DataModel>().Property(b => b.CreateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            modelBuilder.Entity<DataModel>().Property(b => b.UpdateDate).HasDefaultValueSql("NOW()").ValueGeneratedOnAddOrUpdate();
        }
    }
}
