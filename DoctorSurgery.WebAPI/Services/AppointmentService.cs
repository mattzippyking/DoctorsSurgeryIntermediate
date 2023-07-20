using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using DoctorSurgery.WebAPI.Interfaces;

namespace DoctorSurgery.WebAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        /// <summary>
        /// Constructor for the AppointmentService class
        /// </summary>
        /// <param name="appointmentRepository"></param>
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        /// <summary>
        /// Retrieve the Appointment by their unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Appointment> GetByIdAsync(Guid id)
        {
            return await _appointmentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieve all the Appointments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _appointmentRepository.GetAllAsync();
        }

        /// <summary>
        /// Add a Appointment to the List 
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public async Task AddAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAsync(appointment);
        }

        public Task CreateAppointment(Guid patientId, Guid timeSlotId)
        {
            var appointment = new Appointment { PatientId = patientId, SlotId = timeSlotId };
            _appointmentRepository.AddAsync(appointment);
            return Task.CompletedTask;
        }
    }
}
