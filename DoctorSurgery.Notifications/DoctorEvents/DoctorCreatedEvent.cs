using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.Notifications.Events
{
    public class DoctorCreatedEvent
    {
        private Doctor _doctor { get; }
        private DateTime _dateOccurred { get; }

        public DoctorCreatedEvent(Doctor doctor)
        {
            _doctor = doctor; 
            _dateOccurred = DateTime.Now;

            // Send Notifiaction that a new doctor has been created
            string message = "Notification: New Doctor" + System.Environment.NewLine +
                "Doctor Name: " + _doctor.Name + System.Environment.NewLine +
                "Doctor ID: " + _doctor.Id + System.Environment.NewLine +
                "Date Occured: " + _dateOccurred.ToString();
            // TO DO Send notification message
        }

    }
}
