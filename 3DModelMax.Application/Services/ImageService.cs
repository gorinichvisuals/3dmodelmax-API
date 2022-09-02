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
        private readonly I3DModelRepository<_3DModel> _repositoryModel;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository<Image> repository, 
                            I3DModelRepository<_3DModel> repositoryModel, 
                            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _repositoryModel = repositoryModel;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddImages(ICollection<ImageDTO> imageDTOs, int _3DModelId)
        {
            var model = await _repositoryModel.Get3DModelByIdAsync(_3DModelId);

            if (model != null)
            {
                var images = imageDTOs.Select(dto => new Image { File = dto.File }).ToArray();

                await _repository.AddImages(images);
                await _unitOfWork.Save();

                return true;
            }

            return false;
        }       
    }
}