using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Interfaces
{
    public interface IImageRepository<T>
    {
        Task AddImages(ICollection<T> items);
        Task DeleteImageById(int id);
        void UpdateImages(T item);
    }
}
