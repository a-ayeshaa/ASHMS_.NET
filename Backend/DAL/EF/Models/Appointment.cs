using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Doctor")]
        public int Doctor_Id { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime endedAt { get; set; }
        [Required]
        [StringLength(50)]
        public string status { get; set; }
        [Range(0,double.PositiveInfinity)]
        public int revisit_count { get; set; }

        public virtual Doctor Doctor{ get; set; }
        public virtual Patient Patient { get; set; }

    }
}
