using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.WebAPI.Interfaces
{
    public interface IAppointmentService
    {
        public Task<Appointment> GetByIdAsync(Guid id);
        public Task<IEnumerable<Appointment>> GetAllAsync();
        public Task AddAsync(Appointment appointment);
        public Task CreateAppointment(Guid patientId, Guid timeSlotId);
    }
}
