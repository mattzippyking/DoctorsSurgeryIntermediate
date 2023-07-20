using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.Management
{
    public interface ITimeSlotService
    {
        public Task<TimeSlot> GetByIdAsync(Guid id);
        public Task<IEnumerable<TimeSlot>> GetAllAsync();
        public Task<IEnumerable<TimeSlot>> GetByDoctorAsync(Guid doctorId);
        public Task AddAsync(TimeSlot timeSlot);
        public Task CreateSlot(Guid doctorId, DateTime startTime, decimal cost);
    }
}
