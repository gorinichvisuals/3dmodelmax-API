using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.SQLPersistence.Services
{
    public class SQL3DModelsRepository : IRepository<_3DModel>
    {
        private AddDbContext db;

        public SQL3DModelsRepository(AddDbContext addDb)
        {
            db = addDb;
        }

        public async Task<IEnumerable<_3DModel>> Get3DmodelsList()
        {
            return db.Models;
        }

        public async Task<_3DModel> Get3DmodelsById(int id)
        {
            return db.Models.Find(id);
        }

        public async Task Create(_3DModel _3dmodel)
        {
            db.Models.Add(_3dmodel);
        }

        public async Task Update(_3DModel _3dmodel)
        {
            db.Entry(_3dmodel).State = EntityState.Modified;
        }

        public async Task Delete3DmodelsById(int id)
        {
            _3DModel _3dmodel = db.Models.Find(id);
            if (_3dmodel != null)
            {
                db.Models.Remove(_3dmodel);
            }
        }

        public async Task Save()
        {
            db.SaveChanges();
        }
    }
}