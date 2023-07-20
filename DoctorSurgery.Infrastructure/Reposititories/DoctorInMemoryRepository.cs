using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorSurgery.Infrastructure.Reposititories
{
    public class DoctorInMemoryRepository : IDoctorRepository
    {
        private static List<Doctor> _doctors = new List<Doctor>();

        public async Task AddAsync(Doctor doctor)
        {
            await Task.Run(() => _doctors.Add(doctor));
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            await Task.Run(() => _doctors.Remove(doctor));
        }

        /// <summary>
        /// Tests to see if a Doctor with the given unique identifier exists
        /// </summary>
        /// <param name="id">Unique identifier for Doctor</param>
        /// <returns>True if Doctor exists</returns>
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.Run(() => _doctors.Exists(x=> x.Id == id));
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<Doctor>>(_doctors);
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
           return await Task.Run(() => _doctors.FirstOrDefault(x => x.Id == id));
        }

    }
}
