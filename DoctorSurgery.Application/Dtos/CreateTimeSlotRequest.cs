using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.Dtos
{
    public class CreateTimeSlotRequest
    {
        public Guid DoctorId { get; set; }
        public DateTime StartTime { get; set; } 
        public decimal Cost { get; set; }
    }
}
