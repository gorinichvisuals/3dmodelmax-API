using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace _3DModelMax.SQLPersistence.Services
{
    public class SQL3DModelsRepository : I3DModelRepository<_3DModel>
    {
        private AddDbContext db;
        
        public SQL3DModelsRepository(AddDbContext addDb)
        {
            db = addDb;
        }

        public async Task<ICollection<_3DModel>> Get3DModelsListAsync()
        {
            return await db.Models.AsNoTracking().ToListAsync();
        }

        public async Task<_3DModel> Get3DModelByIdAsync(int id)
        {
            return await db.Models.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(_3DModel _3dmodel)
        {
            await db.Models.AddAsync(_3dmodel);
        }

        public void Update(_3DModel _3dmodel)
        {
            db.Models.Update(_3dmodel);
        }

        public async Task Delete3DModelByIdAsync(int id)
        {
            _3DModel _3dmodel = await db.Models.FindAsync(id);

            if (_3dmodel != null)
            {
                db.Models.Remove(_3dmodel);
            }
        }
    }
}