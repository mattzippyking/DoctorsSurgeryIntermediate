using DoctorSurgery.Application.UseCases.TimeSlotCommands;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using Microsoft.AspNetCore.Mvc; 


namespace DoctorSurgery.Management
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSlotController : ControllerBase
    {

        private readonly TimeSlotService _timeSlotService;

        public TimeSlotController(TimeSlotService timeSlotService) 
        {
            _timeSlotService = timeSlotService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeSlot>> GetTimeSlotById(Guid id)
        {
            TimeSlot? timeslot = await _timeSlotService.GetByIdAsync(id);

            if (timeslot == null) 
            { 
                return NotFound();  
            }

            return Ok(timeslot);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<TimeSlot>>> GetTimeSlotsByDoctorId(Guid id) 
        { 
            var timeSlots = await _timeSlotService.GetByDoctorAsync(id);
            return Ok(timeSlots);   
        }

        [HttpPost("doctor/add")]
        public async Task<IActionResult> AddTimeSLot([FromBody] Guid doctorId, [FromBody] DateTime startTime, [FromBody] decimal cost)
        {
            await _timeSlotService.CreateSlot(doctorId, startTime, cost);
            return Ok();
        }


    }
}
