using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Interfaces
{
    public interface IAuthorRepository<T>
    {
        Task<ICollection<T>> GetAuthorsList();
        Task<T> GetAuthById(int id);
        Task DeleteAuthById(int id);
        Task CreateAuth(T item);
        void UpdateAuth(T item);
        Task SaveAuth();
    }
}
