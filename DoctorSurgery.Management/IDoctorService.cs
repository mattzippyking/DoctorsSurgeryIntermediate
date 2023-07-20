using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.Management
{
    public interface IDoctorService
    {
        public interface IDoctorService
        {
            public Task<Doctor> GetByIdAsync(Guid id);
            public Task<IEnumerable<Doctor>> GetAllAsync();
            public Task AddAsync(Doctor doctor);
            public Task CreateDoctor(string name);
        }
    }
}
