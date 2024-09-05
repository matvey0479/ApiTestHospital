using ApiTest.Domain.Entites;

namespace ApiTest.Contracts
{
    public record PatientsRequest(
        string LastName,
        string FirstName,
        string Patronymic,
        string Adress,
        DateTime BirthDate,
        string Gender,
        Guid DepartmentId);

}
