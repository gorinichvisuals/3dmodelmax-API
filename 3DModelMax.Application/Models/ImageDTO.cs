using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DModelMax.Application.Models
{
    public class ImageDTO
    {
        [Required]
        public string Name{ get; set; }

        [Required]
        public int _3DModelId { get; set; }

        [Required]
        public List<IFormFile> File { get; set; }
    }
}