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
        public string Chemical_Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
