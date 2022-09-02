using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Interfaces
{
    public interface IModelService
    {
        Task<bool> CreateModel(_3DModelDTO objModel);
        Task UpdateModel(_3DModelUpdateDTO objModel);
        Task DeleteModelById(int id);
    }
}
