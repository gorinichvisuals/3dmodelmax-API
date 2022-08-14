using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.Host.Models
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> contextOptions) 
            : base(contextOptions)
        {
            
        }

        public DbSet<_3DModels> Models { get; set; }
        public DbSet<Authors> Author { get; set; }
    }   
}
