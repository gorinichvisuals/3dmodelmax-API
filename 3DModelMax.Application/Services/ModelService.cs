using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Services
{
    public class ModelService : IModelService
    {
        private readonly IRepository<_3DModel> _repository;

        public ModelService(IRepository<_3DModel> repository)
        {
            _repository = repository;
        }

        public async Task CreateModel(_3DModelDTO objModel)
        {
            var model = new _3DModel();

            model.Name = objModel.Name;
            model.Description = objModel.Description;
            model.UploadDate = DateTime.Now;
            model.Author = new Author { FirstName = "Boris", LastName = "Johnson", Age = 35, RegistrationDate = DateTime.Now };
            model.File = await UploadDTOFile(objModel.File);

            await _repository.CreateAsync(model);
            await _repository.SaveAsync();
        }  

        public async Task<byte[]> UploadDTOFile(IFormFile fileDTO)
        {
            await using (var file = new MemoryStream())
            {
                fileDTO.CopyTo(file);
                return file.ToArray();
            }
        }

        public async Task UpdateModel(_3DModelUpdateDTO objModel)
        {
            var updModel = await _repository.Get3DModelByIdAsync(objModel.Id);
            updModel.Name = objModel.Name;
            updModel.Description = objModel.Description;
            updModel.LastUpdated = DateTime.Now;
            updModel.File = await UploadDTOFile(objModel.File);

            _repository.Update(updModel);
            await _repository.SaveAsync();
        }

        public async Task DeleteModelById(int id)
        {
            await _repository.Delete3DModelByIdAsync(id);
            await _repository.SaveAsync();
        }
    }
}
