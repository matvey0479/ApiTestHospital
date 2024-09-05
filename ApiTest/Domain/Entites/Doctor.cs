using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Domain.Entites
{
    public class Doctor
    {
        public Doctor() { }
        public Doctor(string fio,Guid cabinetId, Guid specializationId, Guid? departmentId) 
        {
            Fio = fio;
            CabinetId = cabinetId;
            SpecializationId = specializationId;
            DepartmentId = departmentId;
        }

        public Guid Id { get; set; }
        public string Fio { get; set; }
        public Cabinet Cabinet { get; set; }
        public Guid CabinetId { get; set; }
        public Specialization Specialization { get; set; }
        public Guid SpecializationId { get; set; }
        public Department? Department { get; set; }
        public Guid? DepartmentId { get; set; }

    }
}
