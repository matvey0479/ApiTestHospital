namespace ApiTest.Contracts
{
    public record DoctorsRequest(
        string Fio,
        Guid CabinetId,
        Guid SpecId,
        Guid DepartmentId);

}
