using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class TestCart
    {
        public int Id { get; set; }
        [ForeignKey("Test")]
        [Required]
        public int Test_Id { get; set; }
        [ForeignKey("TestTransaction")]
        public int? Test_Transaction_Id { get; set; }
        [ForeignKey("Patient")]
        public int Patient_Id { get; set; }
        public virtual Test Test { get; set; }
        public virtual TestTransaction TestTransaction { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
