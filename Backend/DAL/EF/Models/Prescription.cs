using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("appointment")]
        public int Appointment_Id { get; set; }
        public string Chief_complaint { get; set; } //patient kiki shomossha bolse
        public string On_evaluation { get; set; } //doctor kiki paise
        public string Deduction { get; set; } //doctor ki suspect kortese
        public string Advancement { get; set; } //rest, posture change etc [reccomendations]

        public virtual Appointment appointment { get; set; }
        //public Prescription()
        //{
        //    appointment = new Appointment();
        //}
    }
}
