using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;

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
           
            await using (var file = new MemoryStream())
            {
                objModel.File.CopyTo(file);
                var fileBytes = file.ToArray();
                model.File = fileBytes;
            }
            
            await _repository.CreateAsync(model);
            await _repository.SaveAsync();
        }
    }
}
