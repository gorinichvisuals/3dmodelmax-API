using Microsoft.AspNetCore.Http;

namespace _3DModelMax.Host.Models
{
    public class _3DModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; } 
        public Author Author { get; set; } 
    }
}
