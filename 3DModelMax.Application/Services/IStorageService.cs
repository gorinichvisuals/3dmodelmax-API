using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Persistence.ServicesDTO
{
    public interface IStorageService
    {
        void UploadModel(IFormFile _3DModelDTO);
    }
}
