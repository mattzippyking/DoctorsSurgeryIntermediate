using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Notifications.Events
{
    public class TimeSlotCreatedEvents
    {
        public TimeSlotCreatedEvents(TimeSlot timeSlot) 
        {
            // Send Notifiaction that a new doctor has been created
            string message = "Notification: New Timeslot" + System.Environment.NewLine +
                "Timeslot ID: " + timeSlot.Id.ToString() + System.Environment.NewLine +
                "Doctor ID: " + timeSlot.DoctorId.ToString() + System.Environment.NewLine +
                "Cost: " + timeSlot.Cost.ToString() + System.Environment.NewLine +
                "Date Occured: " + DateTime.Now.ToString();
            // TO DO Send notification message
        }
    }
}
