using ApiTest.Contracts;
using ApiTest.Domain.Entites;
using ApiTest.Domain.Repositories.Abstract;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository _patientsRepository;

        public PatientsController(IPatientsRepository patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientsResponse>>> GetPatients(string? sortItem, string? sortOrder, [FromQuery] PaginationModel? pagination)
        {
            var patients = await _patientsRepository.GetPatientsAsync(sortItem, sortOrder, pagination);
            var response = patients.Select(p => new PatientsResponse(p.Id, p.LastName, p.FirstName, p.Patronymic, p.Adress, p.BirthDate, p.Gender, p.Department));
            return Ok(response);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Patient>> GetPatient(Guid id)
        {
            var patient = await _patientsRepository.GetPatientByIdAsync(id);
            return Ok(patient);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreatePatient([FromBody] PatientsRequest request)
        {
            var patientId = await _patientsRepository.AddPatientAsync(new Patient(request.LastName, request.FirstName, request.Patronymic, request.Adress, request.BirthDate, request.Gender, request.DepartmentId));
            return Ok(patientId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdatePatient(Guid id, [FromBody] PatientsRequest request)
        {
            var patientId = await _patientsRepository.UpdatePatientAsync(id, request.LastName, request.FirstName, request.Patronymic, request.Adress, request.BirthDate, request.Gender, request.DepartmentId);
            return Ok(patientId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeletePatient(Guid id)
        {
            return Ok(await _patientsRepository.DeletePatientAsync(id));
        }

    }
}
