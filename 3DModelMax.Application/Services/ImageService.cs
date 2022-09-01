using _3DModelMax.Application.Interfaces;
using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Interfaces;
using _3DModelMax.Persistence.Models;
using _3DModelMax.Persistence.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository<Image> _repository;
        private readonly I3DModelRepository<_3DModel> _modelRepository;

        public ImageService(IImageRepository<Image> repository, I3DModelRepository<_3DModel> modelRepository)
        {
            _repository = repository;
            _modelRepository = modelRepository;
        }

        public async Task<bool> AddImages(ImageDTO images)
        {
            var model = await _modelRepository.Get3DModelByIdAsync(images._3DModelId);

            if (model != null)
            {
                var imagesList = new List<string>();
                imagesList = await GetImages(images.File);

                return true;
            }
            else 
            {
                return false;
            }
        }

        private async Task<List<string>> GetImages(List<IFormFile> files) 
        {
            List<string> uploadImages = new List<string>();

            foreach(IFormFile file in files)
            {
                string fileName = Path.GetFileName(file.FileName);
                var result = new StringBuilder();

                await using (var fileStream = new MemoryStream())
                {
                    file.CopyTo(fileStream);
                    uploadImages.Add(fileName);
                    result.AppendLine(fileStream.ToString());
                    uploadImages.Add(result.ToString());
                }
            }

            return uploadImages;
        }
    }
}