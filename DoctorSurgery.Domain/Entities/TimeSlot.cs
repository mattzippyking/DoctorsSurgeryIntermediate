using DoctorSurgery.Domain.Common.Interfaces;
using DoctorSurgery.Domain.Enumerations;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorSurgery.Domain.Entities
{
    /// <summary>
    /// Class that represents a Time Slot at the surgery 
    /// </summary>
    public class TimeSlot
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        /// <summary> Unique identification number in Guid format for the TimeSlot </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Identifaction for the Doctor assigned to the slot in Guid format
        /// </summary>
        [Required] public Guid DoctorId { get; set; } = Guid.Empty;

        /// <summary>
        /// Date and time for when the Slot starts
        /// </summary>
        [Required] public DateTime StartTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Cost of the time slot
        /// </summary>
        [Required] public decimal Cost { get; set; } = decimal.Zero;


        public static TimeSlot CreateNew(Guid doctorId, DateTime startTime, decimal cost)
        {
            var timeSlot = new TimeSlot { DoctorId = doctorId, StartTime = startTime, Cost = cost };
            timeSlot._domainEvents.Add(new TimeSlotCreated(timeSlot));
            return timeSlot;
        }

    }

    public record TimeSlotCreated(TimeSlot timeSlot) : IDomainEvent;
}
