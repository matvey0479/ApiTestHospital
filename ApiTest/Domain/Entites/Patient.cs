namespace ApiTest.Domain.Entites
{
    public class Patient
    {
        public Patient() { }
        public Patient(string lastName, string firstName,string patronymic,string adress,DateTime birthDate,string gender,Guid departmentId)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Adress = adress;
            Gender = gender;
            DepartmentId = departmentId;
        }

        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
