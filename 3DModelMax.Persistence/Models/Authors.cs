namespace _3DModelMax.Host.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int _3DModelId { get; set; }

        public ICollection<_3DModels> _3DModels { get; set; }
    }
}
