using _3DModelMax.Host.Models;
using _3DModelMax.Persistence.ServicesDTO;
using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.Persistence.Models
{
    public class SQL3DModelsRepository : IRepository<_3DModel>
    {
        private AddDbContext db;

        public SQL3DModelsRepository(AddDbContext addDb)
        {
            db = addDb;
        }

        public IEnumerable<_3DModel> Get3DmodelsList()
        {
            return db.Model;
        }

        public _3DModel Get3DmodelsById(int id)
        {
            return db.Model.Find(id);
        }

        public void Create(_3DModel _3dmodel)
        {
            db.Model.Add(_3dmodel);
        }

        public void Update(_3DModel _3dmodel)
        {
            db.Entry(_3dmodel).State = EntityState.Modified;
        }

        public void Delete3DmodelsById(int id)
        {
            _3DModel _3dmodel = db.Model.Find(id);
            if (_3dmodel != null)
            {
                db.Model.Remove(_3dmodel);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
