using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.SQLPersistence;

namespace _3DModelMax.Persistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private AddDbContext db;

        public UnitOfWork(AddDbContext db)
        {
            this.db = db;
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}