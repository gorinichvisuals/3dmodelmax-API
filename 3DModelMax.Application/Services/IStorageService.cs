using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Services
{
    public interface IStorageService
    {
        void UploadModel(IFormFile _3DModelDTO);
    }
}
