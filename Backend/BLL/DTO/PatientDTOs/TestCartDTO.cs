using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PatientDTOs
{
    public class TestCartDTO
    {
        public int Id { get; set; }
        [Required]
        public int Test_Id { get; set; }
        public int? Test_Transaction_Id { get; set; }
        [Required]
        public int Patient_Id { get; set; }
    }
}
