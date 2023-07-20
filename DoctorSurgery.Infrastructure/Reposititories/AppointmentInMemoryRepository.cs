using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Infrastructure.Reposititories
{
    public class AppointmentInMemoryRepository : IAppointmentRepository
    {
        private static List<Appointment> _appointments = new List<Appointment>();

        /// <summary>
        /// Adds a new appointment to the the list
        /// </summary>
        /// <param name="appointment">Appointment object to add to list</param>
        /// <returns></returns>
        public async Task AddAsync(Appointment appointment)
        {
            await Task.Run(() => _appointments.Add(appointment));
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            await Task.Run(() => _appointments.Remove(appointment));
        }

        /// <summary>
        /// Tests to see if an Appointment with the given unique identifier exists
        /// </summary>
        /// <param name="id">Unique identifier for an Appointment</param>
        /// <returns>True if an Appointment exists</returns>
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.Run(() => _appointments.Exists(x => x.Id == id));
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<Appointment>>(_appointments);
        }

        public async Task<Appointment?> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _appointments.FirstOrDefault(x => x.Id == id));
        }
    }
}
