using DoctorSurgery.Domain.Entities;
using DoctorSurgery.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSurgery.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {

        private readonly AppointmentService _appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(Guid id)
        {
            Appointment? appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpPost("appointment/add")]
        public async Task<IActionResult> AddAppointment([FromBody] Guid patientId, [FromBody] Guid timeSlotId )
        {
            await _appointmentService.CreateAppointment(patientId, timeSlotId);
            return Ok();
        }

    }
}
