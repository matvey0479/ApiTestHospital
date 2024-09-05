using ApiTest.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiTest.Domain
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Department>().HasData(new Department { Id = new Guid("1ef530e9-c513-4350-850b-03d09febd21f"), Number= 1 });
            modelbuilder.Entity<Department>().HasData(new Department { Id = new Guid("52f3a9bb-af35-4f50-83bb-b47d853a3699"), Number = 2 });
            modelbuilder.Entity<Department>().HasData(new Department { Id = new Guid("5e718002-a929-4eb3-a1f8-fdc33c7d8820"), Number = 3 });
            modelbuilder.Entity<Specialization>().HasData(new Specialization { Id = new Guid("c6f3ab9f-00ea-43e5-8fd7-698d1d3d211e"), Name = "Терапевт" });
            modelbuilder.Entity<Specialization>().HasData(new Specialization { Id = new Guid("d9fe1b73-849d-443a-800a-9f4ee502b38d"), Name = "Хирург" });
            modelbuilder.Entity<Specialization>().HasData(new Specialization { Id = new Guid("03fa870e-d2d9-4ae3-89ac-5eb2cff4254a"), Name = "Стоматолог" });
            modelbuilder.Entity<Cabinet>().HasData(new Cabinet { Id = new Guid("8ac8d4f1-c991-47f4-bf46-978183c9142e"), Number = 1 });
            modelbuilder.Entity<Cabinet>().HasData(new Cabinet { Id = new Guid("e6af2999-da92-4373-9416-d0ba65b78dbe"), Number = 2 });
            modelbuilder.Entity<Cabinet>().HasData(new Cabinet { Id = new Guid("5bd4ee57-7742-4d78-8f1e-7580068cab3d"), Number = 3 });
            modelbuilder.Entity<Cabinet>().HasData(new Cabinet { Id = new Guid("16e11064-6191-4071-be7d-75df802fad63"), Number = 4 });

        }




    }
}
