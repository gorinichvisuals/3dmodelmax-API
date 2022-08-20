using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Host.Models
{
    public class _3DModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; } 
        public IFormFile file { get; set; }
    }
}
