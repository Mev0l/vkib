using Microsoft.EntityFrameworkCore;

namespace vk1
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DGJC3VL;Initial Catalog=vk;Integrated Security=True; Encrypt=True;TrustServerCertificate=True");
            }
        }
    }
}