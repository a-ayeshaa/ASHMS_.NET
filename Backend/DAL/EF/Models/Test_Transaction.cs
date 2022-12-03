using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Test_Transaction
    {
        public int Id { get; set; }
        [ForeignKey("Patient")]
        [Required]
        public int Patient_Id { get; set; }
        [Required]

        public string Reference { get; set; }
        [Required]

        public float Total { get; set; }
        [Required]

        public string Status { get; set; }
        [Required]

        public DateTime Date { get; set; }
        [Required]

        public Boolean Report_Delivered { get; set; }

        public Patient Patient { get; set; }    
    }
}
