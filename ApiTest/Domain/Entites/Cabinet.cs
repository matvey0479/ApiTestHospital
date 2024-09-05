using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Domain.Entites
{
    public class Cabinet
    {
        public Cabinet() { }
        public Cabinet(int number)
        {
            Number = number;
        }
        public Guid Id { get; set; }
        public int Number { get; set; }

    }
}
