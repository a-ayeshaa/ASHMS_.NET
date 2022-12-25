using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class PrescriptionPresMedicineDTO:PrescriptionDTO
    {
        public virtual List<MedicinePrescriptionDTO> MedicinePrescriptions { get; set; }    
        public PrescriptionPresMedicineDTO()
        {
            MedicinePrescriptions = new List<MedicinePrescriptionDTO>();
        }
    }
}
