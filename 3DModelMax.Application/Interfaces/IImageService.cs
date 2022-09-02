using _3DModelMax.Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Interfaces
{
    public interface IImageService
    {
        Task<bool> AddImages(ICollection<ImageDTO> images, int _3DModelId);
    }
}
