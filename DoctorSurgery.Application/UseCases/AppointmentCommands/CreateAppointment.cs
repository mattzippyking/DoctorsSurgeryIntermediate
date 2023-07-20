using DoctorSurgery.Application.Dtos;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.UseCases.AppointmentCommands
{
    public class CreateAppointment
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public CreateAppointment(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task Execute(CreateAppointmentRequest request)
        {
            var appointment = Appointment.CreateNew(request.PatientID, request.TimeSlotID);
            await _appointmentRepository.AddAsync(appointment);
        }
    }
}
