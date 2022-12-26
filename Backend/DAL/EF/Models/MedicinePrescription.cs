using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class MedicinePrescription
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Prescription")]
        public int Prescription_Id { get; set; }
        [Required]
        [ForeignKey("Medicine")]
        public int Medicine_Id { get; set; }
        [StringLength(50)]
        public string Doze { get; set; }
        [StringLength(int.MaxValue)]
        public string Continuation { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Medicine Medicine { get; set; }

    }
}
