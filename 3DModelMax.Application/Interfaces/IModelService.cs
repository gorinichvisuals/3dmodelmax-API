using _3DModelMax.Application.Models;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Interfaces
{
    public interface IModelService
    {
        Task CreateModel(_3DModelDTO objModel);
    }
}
