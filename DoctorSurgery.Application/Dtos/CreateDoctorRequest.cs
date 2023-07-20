using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorSurgery.Application.Dtos
{
    public class CreateDoctorRequest
    {
        [Required]
        public string DoctorName { get; set; }
    }
}
