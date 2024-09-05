using ApiTest.Domain.Entites;
using ApiTest.Domain.Repositories.Abstract;
using ApiTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiTest.Domain.Repositories.EntityFramework
{
    public class EFPatientRepository : IPatientsRepository
    {
        private readonly HospitalDbContext _context;
        public EFPatientRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }
        public async Task<Guid> UpdatePatientAsync(Guid id, string lastName, string firstName, string patronymic, string adress, DateTime birthDate, string gender, Guid departmenttId)
        {
            await _context.Patients
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.LastName, p => lastName)
                .SetProperty(p => p.FirstName, p => firstName)
                .SetProperty(p => p.Patronymic, p => patronymic)
                .SetProperty(p => p.Adress, p => adress)
                .SetProperty(p => p.BirthDate, p => birthDate)
                .SetProperty(p => p.Gender, p => gender)
                .SetProperty(p => p.DepartmentId, p => departmenttId));

            return id;
        }
        public async Task<Guid> DeletePatientAsync(Guid id)
        {
            await _context.Patients
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }

        public async Task<List<Patient>> GetPatientsAsync(string? sortItem, string? sortOrder, PaginationModel? pagination)
        {
            var patientsQueri = _context.Patients.Include(d => d.Department);
            Expression<Func<Patient, object>> selectorKey = sortItem?.ToLower() switch
            {
                "lastname" => patient => patient.LastName,
                "adress" => patient => patient.Adress,
                "birthdate" => patient => patient.BirthDate,
                "gender" => patient => patient.Gender,
                "department" => patient => patient.Department,
                _ => patient => patient.Id
            };

            if (sortOrder == "desc")
            {
                return await patientsQueri.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .OrderByDescending(selectorKey)
                    .ToListAsync();
            }
            else
            {
                return await patientsQueri.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize)
                    .OrderBy(selectorKey)
                    .ToListAsync();
            }
        }
        public async Task<Patient> GetPatientByIdAsync(Guid id)
        {
            return await _context.Patients.Include(d=>d.Department)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
