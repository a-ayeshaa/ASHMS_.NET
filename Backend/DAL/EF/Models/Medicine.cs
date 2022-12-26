using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Chemical_Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public virtual List<MedicinePrescription> MedicinePrescriptions { get; set; }
        public Medicine()
        {
            //appointment = new Appointment();
            MedicinePrescriptions = new List<MedicinePrescription>();
        }
    }
}
