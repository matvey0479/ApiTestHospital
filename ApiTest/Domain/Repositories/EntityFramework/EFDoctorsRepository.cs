using ApiTest.Domain.Entites;
using ApiTest.Domain.Repositories.Abstract;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiTest.Domain.Repositories.EntityFramework
{
    public class EFDoctorsRepository : IDoctorsRepository
    {
        private readonly HospitalDbContext _context;
        public EFDoctorsRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor.Id;
        }
        public async Task<Guid> UpdateDoctorAsync(Guid id, string fio, Guid cabinetId, Guid specializationId, Guid? departmentId)
        {
            await _context.Doctors
              .Where(d => d.Id == id)
              .ExecuteUpdateAsync(s => s
              .SetProperty(d => d.Fio, d => fio)
              .SetProperty(d => d.CabinetId, d => cabinetId)
              .SetProperty(d => d.SpecializationId, d => specializationId)
              .SetProperty(d => d.DepartmentId, d => departmentId));

            return id;
        }
        public async Task<Guid> DeleteDoctorAsync(Guid id)
        {
            await _context.Doctors
               .Where(d => d.Id == id)
               .ExecuteDeleteAsync();

            return id;
        }
        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _context.Doctors.Include(d => d.Cabinet)
                                         .Include(d => d.Specialization)
                                         .Include(d => d.Department)
                                         .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<Doctor>> GetDoctorsAsync(string? sortItem, string? sortOrder, PaginationModel pagination)
        {
            var doctorsQueri = _context.Doctors.Include(d => d.Cabinet)
                                                .Include(d => d.Specialization)
                                                .Include(d => d.Department);
            Expression<Func<Doctor, object>> selectorKey = sortItem?.ToLower() switch
            {
                "fio" => doc => doc.Fio,
                "cabinet" => doc => doc.Cabinet.Number,
                "spec" => doc => doc.Specialization.Name,
                "department" => doc => doc.Department.Number,
                _ => doc => doc.Id
            };

            if (sortOrder == "desc")
            {
                return await doctorsQueri.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                        .Take(pagination.PageSize)
                                        .OrderByDescending(selectorKey)
                                        .ToListAsync();
            }
            else
            {
                return await doctorsQueri.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                        .Take(pagination.PageSize)
                                        .OrderBy(selectorKey)
                                        .ToListAsync();
            }
        }
    }
}
