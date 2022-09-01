﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Interfaces
{
    public interface IImageRepository<T>
    {
        Task<ICollection<T>> GetAllImages();
        Task AddImages(ICollection<T> items);
        Task<T> GetImageById(int id);
        Task DeleteImagesById(int id);
        void UpdateImages(T item);
        Task SaveImages();
    }
}
