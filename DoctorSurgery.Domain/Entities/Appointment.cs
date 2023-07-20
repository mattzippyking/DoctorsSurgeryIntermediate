using DoctorSurgery.Domain.Common.Interfaces;
using DoctorSurgery.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Domain.Entities
{
    /// <summary>
    /// Class that represents an Appointment at the Surgery
    /// </summary>
    public class Appointment
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        /// <summary> Unique identification number in Guid format for the Appointment </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Reference identification for the Patient in Guid format
        /// </summary>
        [Required] public Guid PatientId { get; set; } = Guid.Empty;

        /// <summary>
        /// Reference identification for the Slot in Guid format
        /// </summary>
        [Required] public Guid SlotId { get; set; } = Guid.Empty;

        /// <summary>
        /// Date and time for when the appointment was created
        /// </summary>
        [Required] public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Status of the Appointment
        /// </summary>
        [Required] public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;


        public static Appointment CreateNew(Guid patientId, Guid slotId)
        {
            var appointment = new Appointment { PatientId = patientId, SlotId = slotId };
            appointment._domainEvents.Add(new AppointmentCreated(appointment));
            return appointment;
        }

    }

    public record AppointmentCreated(Appointment appointment) : IDomainEvent;
}
