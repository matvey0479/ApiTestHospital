using ApiTest.Domain.Entites;
using ApiTest.Models;

namespace ApiTest.Domain.Repositories.Abstract
{
    public interface IDoctorsRepository
    {
        public Task<Guid> AddDoctorAsync(Doctor doctor);
        public Task<Guid> UpdateDoctorAsync(Guid id, string fio, Guid cabinetId, Guid specializationId, Guid? departmentId);
        public Task<Guid> DeleteDoctorAsync(Guid id);
        public Task<Doctor> GetDoctorByIdAsync(Guid id);
        public Task<List<Doctor>> GetDoctorsAsync(string? sortItem, string? sortOrder, PaginationModel pagination);
    }
}
