using _3DModelMax.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.SQLPersistence
{
    public class AddDbContext : DbContext
    {
        public DbSet<_3DModel> Models { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        public AddDbContext()
        {
            
        }
        
        public AddDbContext(DbContextOptions<AddDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\\SQLEXPRESS;Database=3dmodels;Trusted_Connection=True");
            }
        }
    }   
}
