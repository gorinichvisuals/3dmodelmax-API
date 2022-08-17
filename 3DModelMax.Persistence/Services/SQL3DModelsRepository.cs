using _3DModelMax.Host.Models;
using Microsoft.EntityFrameworkCore;

namespace _3DModelMax.Persistence.Services
{
    internal class SQL3DModelsRepository : IRepository<_3DModels>
    {
        private AddDbContext db;

        public SQL3DModelsRepository()
        {
            this.db = new AddDbContext();
        }

        public IEnumerable<_3DModels> Get3DmodelsList()
        {
            return db.Models;
        }

        public _3DModels Get3DmodelsById(int id)
        {
            return db.Models.Find(id);
        }

        public void Create(_3DModels _3dmodel)
        {
            db.Models.Add(_3dmodel);
        }

        public void Update(_3DModels _3dmodel)
        {
            db.Entry(_3dmodel).State = EntityState.Modified;
        }

        public void Delete3DmodelsById(int id)
        {
            _3DModels _3dmodel = db.Models.Find(id);
            if (_3dmodel != null)
                db.Models.Remove(_3dmodel);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
