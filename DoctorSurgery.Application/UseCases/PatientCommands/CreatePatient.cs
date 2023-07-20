using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DoctorSurgery.Application.Dtos;

namespace DoctorSurgery.Application.UseCases.PatientCommands
{
    public class CreatePatient
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatient(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Execute(CreatePatientRequest request)
        {
            var patient = Patient.CreateNew(request.PatientName);
            await _patientRepository.AddAsync(patient);
        }

    }
}
