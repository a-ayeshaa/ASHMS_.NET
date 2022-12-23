using BLL.DTO.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class DoctorAppointmentDTO : DoctorDTO
    {
        public virtual List<AppointmentPatientDTO> Appointments { get; set; }
        //public virtual PatientDTO Patients { get; set; }
        public DoctorAppointmentDTO()
        {
            Appointments = new List<AppointmentPatientDTO>();
            //Patients = new List<PatientDTO>();
        }

    }
}
