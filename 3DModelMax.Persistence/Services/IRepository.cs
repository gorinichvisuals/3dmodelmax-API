using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.ServicesDTO
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get3DmodelsList();
        T Get3DmodelsById(int id);
        void Delete3DmodelsById(int id);
        void Create(T item);
        void Update(T item);
        void Save();
    }
}
