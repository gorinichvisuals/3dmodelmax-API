﻿using _3DModelMax.Application.Models;
using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Interfaces
{
    public interface IModelService
    {
        Task CreateModel(_3DModelDTO objModel);
        Task<bool> UpdateModel(_3DModelUpdateDTO objModel);
        Task DeleteModelById(int id);
    }
}
