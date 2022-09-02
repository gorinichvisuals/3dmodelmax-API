using System.ComponentModel.DataAnnotations;

namespace _3DModelMax.Persistence.Models
{
    public class _3DModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } 
        public byte[] File { get; set; }
        public DateTime? LastUpdated { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
