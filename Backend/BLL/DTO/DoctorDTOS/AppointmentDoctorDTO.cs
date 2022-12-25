using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class AppointmentDoctorDTO:AppointmentDTO
    {
        public virtual DoctorDTO Doctor { get; set; }
    }
}
