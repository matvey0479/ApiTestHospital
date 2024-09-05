using ApiTest.Domain.Entites;
using ApiTest.Models;

namespace ApiTest.Domain.Repositories.Abstract
{
    public interface IPatientsRepository
    {
        public Task<Guid> AddPatientAsync(Patient patient);
        public Task<Guid> UpdatePatientAsync(Guid id, string lastName,string firstName,string patronymic,string adress,DateTime birthDate,string gender,Guid departmentId);
        public Task<Guid> DeletePatientAsync(Guid id);
        public Task<Patient> GetPatientByIdAsync(Guid id);
        public Task<List<Patient>> GetPatientsAsync(string? sortItem, string? sortOrder,PaginationModel pagination);

    }
}
