using Microsoft.EntityFrameworkCore;

namespace PropensityTrackerCore.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base()
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=tcp:aspgc.database.windows.net,1433;Initial Catalog=asp;Persist Security Info=False;User ID=asp;Password=georgian1234@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-VSTAS6O\\SQLEXPRESS;Initial Catalog=PropensityTrack;Integrated Security=true;Encrypt=False;TrustServerCertificate=True;");
        }
        
        public DbSet<UserMaster> UserMasters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMaster>().ToTable("UserMaster");
        }
    }
}