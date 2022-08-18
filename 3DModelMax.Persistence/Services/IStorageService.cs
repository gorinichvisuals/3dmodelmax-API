using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.ServicesDTO
{
    public interface IStorageService
    {
        void UploadModel(IFormFile _3DModelDTO);
    }
}
