using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Services
{
    public class ModelService : IModelService
    {
        private readonly I3DModelRepository<_3DModel> _repository;

        public ModelService(I3DModelRepository<_3DModel> repository)
        {
            _repository = repository;
        }

        public async Task CreateModel(_3DModelDTO objModel)
        {
            var model = new _3DModel();

            model.Name = objModel.Name;
            model.Description = objModel.Description;
            model.UploadDate = DateTime.Now;
            model.File = await GetFileBytes(objModel.File);
            model.AuthorId = objModel.AuthorId;
            await _repository.CreateAsync(model);
            await _repository.SaveAsync();
        }  

        public async Task UpdateModel(_3DModelUpdateDTO objModel)
        {
            var updModel = await _repository.Get3DModelByIdAsync(objModel.Id);
            updModel.Name = objModel.Name;
            updModel.Description = objModel.Description;
            updModel.LastUpdated = DateTime.Now;
            updModel.File = await GetFileBytes(objModel.File);

            _repository.Update(updModel);
            await _repository.SaveAsync();
        }

        public async Task DeleteModelById(int id)
        {
            await _repository.Delete3DModelByIdAsync(id);
            await _repository.SaveAsync();
        }

        private async Task<byte[]> GetFileBytes(IFormFile file)
        {
            await using (var newFile = new MemoryStream())
            {
                file.CopyTo(newFile);
                return newFile.ToArray();
            }
        }
    }
}
