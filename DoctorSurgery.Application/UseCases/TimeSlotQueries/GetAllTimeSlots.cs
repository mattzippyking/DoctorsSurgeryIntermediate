using DoctorSurgery.Application.Dtos;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.UseCases.TimeSlotQueries
{
    public class GetAllTimeSlots
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public GetAllTimeSlots(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task<IEnumerable<TimeSlot>> Execute()
        {
           return await _timeSlotRepository.GetAllAsync();   
        }
    }
}
