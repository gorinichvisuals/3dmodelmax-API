using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.Host.Models
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> contextOptions) 
            : base(contextOptions)
        {
            
        }

        public AddDbContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True");
        }

        public DbSet<_3DModel> Model { get; set; }
        public DbSet<Author> Author { get; set; }
    }   
}
