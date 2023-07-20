using DoctorSurgery.Application.Dtos;
using DoctorSurgery.Application.UseCases.TimeSlotCommands;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;

namespace DoctorSurgery.Management
{
    public class TimeSlotService : ITimeSlotService
    {

        private readonly ITimeSlotRepository _timeSlotRepository;

        /// <summary>
        /// Constructor for the TimeSlotService class
        /// </summary>
        /// <param name="timeSlotRepository"></param>
        public TimeSlotService(ITimeSlotRepository timeSlotRepository)
        { 
            _timeSlotRepository = timeSlotRepository;
        }

        /// <summary>
        /// Retrieve the TimeSlot by its unique identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TimeSlot> GetByIdAsync(Guid id)
        {
            return await _timeSlotRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Retrieve all the TimeSlots
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TimeSlot>> GetAllAsync()
        {
            return await _timeSlotRepository.GetAllAsync();
        }


        /// <summary>
        /// Retrieves all the TimeSlots for a doctor
        /// </summary>
        /// <param name="doctorId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TimeSlot>> GetByDoctorAsync(Guid doctorId)
        {
            return await _timeSlotRepository.GetByDoctorIdAsync(doctorId);
        }

        /// <summary>
        /// Add a TimeSlot to the List 
        /// </summary>
        /// <param name="timeSlot"></param>
        /// <returns></returns>
        public async Task AddAsync(TimeSlot timeSlot)
        {
            await _timeSlotRepository.AddAsync(timeSlot);
        }

        public Task CreateSlot(Guid doctorId, DateTime startTime, decimal cost)
        {
            var slot = new TimeSlot { DoctorId = doctorId, StartTime = startTime, Cost = cost };
            _timeSlotRepository.AddAsync(slot);
            return Task.CompletedTask;
        }


    }
}
