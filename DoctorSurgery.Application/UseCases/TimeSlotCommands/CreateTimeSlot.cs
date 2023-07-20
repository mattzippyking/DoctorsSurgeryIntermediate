using DoctorSurgery.Application.Dtos;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.UseCases.TimeSlotCommands
{
    public class CreateTimeSlot
    {
        private readonly ITimeSlotRepository _timeSlotRepository;

        public CreateTimeSlot(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }

        public async Task Execute(CreateTimeSlotRequest request)
        {
            var timeSlot = TimeSlot.CreateNew(request.DoctorId, request.StartTime, request.Cost);
            await _timeSlotRepository.AddAsync(timeSlot);
        }
    }
}
