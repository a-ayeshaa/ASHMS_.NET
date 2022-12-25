using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.DoctorDTOS
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime? endedAt { get; set; }
        public string status { get; set; }
        public int revisit_count { get; set; }
    }
}
