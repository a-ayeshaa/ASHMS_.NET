using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.UserDTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        [Required]
        public int Patient_id { get; set; }

        [Required]
        public int Doctor_id { get; set; }

        [Required]
        public float Total_Amount { get; set; }

        [Required]
        public float Doctor_Charge { get; set; }

        [Required]
        public float Hospital_Revenue { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Boolean status { get; set; }
    }
}
