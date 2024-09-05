namespace ApiTest.Domain.Entites
{
    public class Specialization
    {
        public Specialization() { }
        public Specialization(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
