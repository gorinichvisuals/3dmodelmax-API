using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Persistence.Services
{
    internal interface IStorageService
    {
        void UploadModel(IFormFile file);
    }
}
