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
        [Required]
        [ForeignKey("Test_Transaction")]
        public int Test_Transaction_Id { get; set; }
        public Test Test { get; set; }
        public Test_Transaction Test_Transaction { get; set; }
    }
}
