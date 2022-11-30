using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string Degree { get; set; }
        public string VisitingDays { get; set; }
        public float Appointment_Fees { get; set; }
        public float? Net_Earnings { get; set; }
        public int UserId { get; set; }
    }
}
