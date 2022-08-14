namespace _3DModelMax.Host.Models
{
    public class Authors
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }

        public Authors(int id, string firstName, string lastName, int age)
        {
            Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
