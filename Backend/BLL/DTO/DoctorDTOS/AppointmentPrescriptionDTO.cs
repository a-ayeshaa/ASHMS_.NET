using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class AppointmentPrescriptionDTO:AppointmentDTO
    {
        public virtual List<PrescriptionDTO> Prescription { get; set; }
        public AppointmentPrescriptionDTO()
        {
            Prescription = new List<PrescriptionDTO>();
        }
    }
}
