using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Interfaces
{
    public interface IStorageService
    {
        void UploadModel(IFormFile _3DModelDTO);
    }
}
