using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using DoctorSurgery.WebAPI.Interfaces;

namespace DoctorSurgery.WebAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        /// <summary>
        /// Constructor for the PatientService class
        /// </summary>
        /// <param name="patientRepository"></param>
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Retrieve the Patient by their unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Patient> GetByIdAsync(Guid id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieve all the Patients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        /// <summary>
        /// Add a Patient to the List 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task AddAsync(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
        }

        public Task CreatePatient(string name)
        {
            var patient = new Patient { Name = name };
            _patientRepository.AddAsync(patient);
            return Task.CompletedTask;
        }
    }
}
