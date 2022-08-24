using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Application.Models
{
    public class _3DModelDTO 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
