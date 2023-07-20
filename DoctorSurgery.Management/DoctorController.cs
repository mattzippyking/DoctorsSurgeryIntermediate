using DoctorSurgery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSurgery.Management
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {

        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlot>> GetById(Guid id)
        {
            Doctor? doctor = await _doctorService.GetByIdAsync(id); 

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost("doctor/add")]
        public async Task<IActionResult> AddTimeSLot([FromBody] string name)
        {
            await _doctorService.CreateDoctor(name);
            return Ok();
        }

    }
}
