using ApiTest.Domain.Entites;

namespace ApiTest.Contracts
{
    public record PatientsResponse(
        Guid Id,
        string LastName,
        string FirstName,
        string Patronymic,
        string Adress,
        DateTime BirthDate,
        string Gender,
        Department Department);

}
