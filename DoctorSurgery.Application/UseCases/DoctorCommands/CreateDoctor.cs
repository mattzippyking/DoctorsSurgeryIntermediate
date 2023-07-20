using DoctorSurgery.Application.Dtos;
using DoctorSurgery.Domain.Contracts;
using DoctorSurgery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.UseCases.DoctorCommands
{
    public class CreateDoctor
    {
        private readonly IDoctorRepository _doctorRepository;

        /// <summary>
        /// Constructor for the CreateDoctor class
        /// </summary>
        /// <param name="doctorRepository"></param>
        public CreateDoctor(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task Execute(CreateDoctorRequest request)
        {
            var doctor = Doctor.CreateNew(request.DoctorName);
            await _doctorRepository.AddAsync(doctor);
        }
    }
}
