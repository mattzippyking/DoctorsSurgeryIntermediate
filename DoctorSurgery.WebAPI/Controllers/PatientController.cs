using DoctorSurgery.Domain.Entities;
using DoctorSurgery.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSurgery.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetById(Guid id)
        {
            Patient? patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost("patient/add")]
        public async Task<IActionResult> AddPatient([FromBody] string name)
        {
            await _patientService.CreatePatient(name);
            return Ok();
        }

    }
}
