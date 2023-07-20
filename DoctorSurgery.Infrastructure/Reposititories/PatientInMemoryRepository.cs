using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Infrastructure.Reposititories
{
    public class PatientInMemoryRepository : IPatientRepository
    {

        private static List<Patient> _patients = new List<Patient>();

        public async Task AddAsync(Patient patient)
        {
            await Task.Run(() => _patients.Add(patient));
        }

        public async Task DeleteAsync(Patient patient)
        {
            await Task.Run(() => _patients.Remove(patient));
        }

        /// <summary>
        /// Tests to see if a Patient with the given unique identifier exists
        /// </summary>
        /// <param name="id">Unique identifier for Patient</param>
        /// <returns>True if Patient exists</returns>
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.Run(() => _patients.Exists(x => x.Id == id));
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<Patient>>(_patients);
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _patients.FirstOrDefault(x => x.Id == id));
        }
    }
}
