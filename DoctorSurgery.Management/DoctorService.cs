using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.Management
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        /// <summary>
        /// Constructor for the DoctorService class
        /// </summary>
        /// <param name="doctorSlotRepository"></param>
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        /// <summary>
        /// Retrieve the Doctor by their unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Doctor> GetByIdAsync(Guid id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieve all the Doctors
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        /// <summary>
        /// Add a Doctor to the List 
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public async Task AddAsync(Doctor doctor)
        {
            await _doctorRepository.AddAsync(doctor);
        }

        public Task CreateDoctor(string name)
        {
            var doctor = new Doctor { Name = name };
            _doctorRepository.AddAsync(doctor);
            return Task.CompletedTask;
        }
    }
}
