using _3DModelMax.Persistence.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace _3DModelMax.Application.Models
{
    public class _3DModelUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}