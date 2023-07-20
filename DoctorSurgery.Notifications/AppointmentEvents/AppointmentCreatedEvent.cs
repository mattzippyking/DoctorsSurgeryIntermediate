using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Notifications.Events
{
    public class AppointmentCreatedEvent
    {
        private Appointment _appointment { get; }
        private DateTime _dateOccurred { get; }

        public AppointmentCreatedEvent(Appointment appointment)
        {
            _appointment = appointment;
            _dateOccurred = DateTime.Now;
            
            // Send Notifiaction that a new doctor has been created
            string message = "Notification: New Appointment" + System.Environment.NewLine +
                "Appointment ID: " + _appointment.Id.ToString() + System.Environment.NewLine +
                "Date Occured: " + _dateOccurred.ToString();
            // TO DO Send notification message
        }
    }
}
