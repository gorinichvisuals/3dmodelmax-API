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
        private readonly I3DModelRepository<_3DModel> _modelRepository;
        private readonly IAuthorRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public ModelService(I3DModelRepository<_3DModel> modelRepository, 
                            IAuthorRepository<Author> authorRepository,
                            IUnitOfWork unitOfWork,
                            IImageService imageService)
        {
            _modelRepository = modelRepository;
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }

        public async Task<bool> CreateModel(_3DModelDTO objModel)
        {
            var author = await _authorRepository.GetAuthorById(objModel.AuthorId);

            if (author != null)
            {
                var model = new _3DModel();

                model.Name = objModel.Name;
                model.Description = objModel.Description;
                model.UploadDate = DateTime.Now;
                model.File = await GetFileBytes(objModel.File);
                model.AuthorId = objModel.AuthorId;

                await _modelRepository.CreateAsync(model);
                await _unitOfWork.Save();

                await _imageService.AddImages(objModel.Images, model.Id);

                return true;
            }
            else 
            {
                return false;
            }
        }

        public async Task UpdateModel(_3DModelUpdateDTO objModel)
        {
            var updModel = await _modelRepository.Get3DModelByIdAsync(objModel.Id);
           
            updModel.Name = objModel.Name;
            updModel.Description = objModel.Description;
            updModel.LastUpdated = DateTime.Now;
            updModel.File = await GetFileBytes(objModel.File);

            _modelRepository.Update(updModel);
            await _unitOfWork.Save();
        }

        public async Task DeleteModelById(int id)
        {
            await _modelRepository.Delete3DModelByIdAsync(id);
            await _unitOfWork.Save();
        }
        public async Task GetModelById(int id) 
        {
            await _modelRepository.Get3DModelByIdAsync(id);
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
