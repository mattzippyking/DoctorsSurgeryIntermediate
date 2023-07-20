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
    /// Class representing a Patient
    /// </summary>
    public class Patient
    {

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        /// <summary> Unique identification number in Guid format for the Patient </summary>
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Name of the Patient
        /// </summary>
        [Required] 
        public string Name { get; set; }  = string.Empty;

        public static Patient CreateNew(string name) 
        {
            var patient = new Patient { Name = name };
            patient._domainEvents.Add(new PatientCreated(patient));
            return patient;
        }

    }

    public record PatientCreated(Patient patient) : IDomainEvent; 
}
