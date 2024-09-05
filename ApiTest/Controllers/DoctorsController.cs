using ApiTest.Contracts;
using ApiTest.Domain.Entites;
using ApiTest.Domain.Repositories.Abstract;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepository _doctorsRepository;

        public DoctorsController(IDoctorsRepository doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorsResponse>>> GetDoctors(string? sortItem, string? sortOrder, [FromQuery] PaginationModel? pagination)
        {
            var Doctors = await _doctorsRepository.GetDoctorsAsync(sortItem, sortOrder, pagination);
            var response = Doctors.Select(d => new DoctorsResponse(d.Id, d.Fio, d.Cabinet.Number, d.Specialization.Name, d.Department.Number));
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Doctor>> GetDoctor(Guid id)
        {
            var Doctor = await _doctorsRepository.GetDoctorByIdAsync(id);
            return Ok(Doctor);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDoctor([FromBody] DoctorsRequest request)
        {
            var DoctorId = await _doctorsRepository.AddDoctorAsync(new Doctor(request.Fio, request.CabinetId, request.SpecId, request.DepartmentId));
            return Ok(DoctorId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateDoctor(Guid id, [FromBody] DoctorsRequest request)
        {
            var DoctorId = await _doctorsRepository.UpdateDoctorAsync(id, request.Fio, request.CabinetId, request.SpecId, request.DepartmentId);
            return Ok(DoctorId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteDoctor(Guid id)
        {
            return Ok(await _doctorsRepository.DeleteDoctorAsync(id));
        }

    }
}
