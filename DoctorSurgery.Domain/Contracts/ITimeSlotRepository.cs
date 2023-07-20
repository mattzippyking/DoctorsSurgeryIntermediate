using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Domain.Contracts
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlot?> GetByIdAsync(Guid id);
        Task<IEnumerable<TimeSlot>> GetAllAsync();
        Task<IEnumerable<TimeSlot>> GetByDoctorIdAsync(Guid id);
        Task AddAsync(TimeSlot timeSlot);
        Task DeleteAsync(TimeSlot timeSlot);
        Task<bool> ExistsAsync(Guid id);
    }
}
