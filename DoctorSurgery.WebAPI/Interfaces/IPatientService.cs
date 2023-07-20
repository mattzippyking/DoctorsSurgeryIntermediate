using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.WebAPI.Interfaces
{
    public interface IPatientService
    {
        public Task<Patient> GetByIdAsync(Guid id);
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task AddAsync(Patient patient);
        public Task CreatePatient(string name);
    }
}
