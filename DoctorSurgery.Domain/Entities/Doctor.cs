using DoctorSurgery.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Domain.Entities
{
    /// <summary>
    /// Class that represents a Doctor
    /// </summary>
    public class Doctor
    {
        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        /// <summary> Unique identification number in Guid format for the Doctor </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Name of the Doctor
        /// </summary>
        [Required] 
        public string Name { get; set; } = string.Empty;

        public static Doctor CreateNew(string name)
        {
            var doctor = new Doctor { Name = name };
            doctor._domainEvents.Add(new DoctorCreated(doctor));
            return doctor;
        }
    }

    public record DoctorCreated(Doctor doctor) : IDomainEvent;
}