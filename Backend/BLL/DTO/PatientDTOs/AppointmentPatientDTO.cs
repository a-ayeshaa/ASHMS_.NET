using BLL.DTO.DoctorDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PatientDTOs
{
    public class AppointmentPatientDTO: AppointmentDTO
    {
        public virtual PatientDTO Patient { get; set; }

    }
}
