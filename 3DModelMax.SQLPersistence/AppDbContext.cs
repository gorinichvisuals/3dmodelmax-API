using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.Host.Models
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> contextOptions) 
            : base(contextOptions)
        {
            
        }

        public DbSet<_3DModel> Model { get; set; }
        public DbSet<Author> Author { get; set; }
    }   
}
