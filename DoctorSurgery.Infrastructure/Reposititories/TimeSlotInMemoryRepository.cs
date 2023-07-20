using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Infrastructure.Reposititories
{
    public class TimeSlotInMemoryRepository : ITimeSlotRepository
    {
        private static List<TimeSlot> _timeSlots = new List<TimeSlot>();

        public async Task AddAsync(TimeSlot timeSlot)
        {
            await Task.Run(() => _timeSlots.Add(timeSlot));
        }

        public async Task DeleteAsync(TimeSlot timeSlot)
        {
            await Task.Run(() => _timeSlots.Remove(timeSlot));
        }

        public async Task<IEnumerable<TimeSlot>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<TimeSlot>>(_timeSlots);
        }

        public async Task<TimeSlot?> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _timeSlots.FirstOrDefault(x => x.Id == id));
        }

        /// <summary>
        /// Tests to see if a TimeSlot with the given unique identifier exists
        /// </summary>
        /// <param name="id">Unique identifier for TimeSlot</param>
        /// <returns>True if TimeSlot exists</returns>
        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.Run(() => _timeSlots.Exists(x => x.Id == id));
        }

        /// <summary>
        /// Retrive all the TimeSlots for a Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TimeSlot>> GetByDoctorIdAsync(Guid id)
        {
            return await Task.Run(() => _timeSlots.Where(x => x.DoctorId == id));
        }

    }
}
