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
        Task<T> GetAuthorById(int id);
        Task DeleteAuthorById(int id);
        Task CreateAuthor(T item);
        void UpdateAuthor(T item);
    }
}
