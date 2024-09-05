namespace ApiTest.Contracts
{
    public record DoctorsResponse(
        Guid Id,
        string Fio,
        int CabinetNumber,
        string SpecializationName,
        int DepartmentNumber);

}
