using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Domain.Entites
{
    public class Department
    {
        public Department() { }
        public Department(int number)
        {
            Number = number;
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
    }
}
