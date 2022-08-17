using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Services
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get3DmodelsList();
        T Get3DmodelsById(int id);
        void Delete3DmodelsById(int id);
        void Create(T item);
        void Update(T item);
        void Save();
    }
}
