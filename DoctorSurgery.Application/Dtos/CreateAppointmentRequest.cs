using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.Dtos
{
    public class CreateAppointmentRequest
    {
        public Guid PatientID { get; set; }
        public Guid TimeSlotID { get; set; }
    }
}
