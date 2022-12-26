using BLL.DTO.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class Med_MedPresDTO:MedicinePrescriptionDTO
    {
        public virtual MedicineDTO Medicine { get; set; }
        
    }
}
