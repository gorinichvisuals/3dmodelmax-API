using System.ComponentModel.DataAnnotations;

namespace _3DModelMax.Persistence.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<_3DModel> _3DModels { get; set; }
    }
}
