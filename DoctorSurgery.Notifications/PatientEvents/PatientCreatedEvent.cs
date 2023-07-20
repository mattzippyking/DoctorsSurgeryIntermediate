using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Notifications.Events
{

    public class PatientCreatedEvent
    {
        private Patient _patient { get; }
        private DateTime _dateOccurred { get; }

        public PatientCreatedEvent(Patient patient)
        {
            _patient = patient;
            _dateOccurred = DateTime.Now;

            // Send Notifiaction that a new doctor has been created
            string message = "Notification: New Patient" + System.Environment.NewLine +
                "Patient Name: " + _patient.Name + System.Environment.NewLine +
                "Patient ID: " + _patient.Id + System.Environment.NewLine +
                "Date Occured: " + _dateOccurred.ToString();
            // TO DO Send notification message
        }

    }
}
