using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class MedicinePrescriptionDTO
    {
        public int Id { get; set; }
        public int Prescription_Id { get; set; } 
        public int Medicine_Id { get; set; }
        public string Doze { get; set; }
        public string Continuation { get; set; }
    }
}
