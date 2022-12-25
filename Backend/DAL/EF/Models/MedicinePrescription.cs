﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class MedicinePrescription
    {
        public int Id { get; set; }
        [Required]
        public int Prescription_Id { get; set; }
        [Required]
        public int Medicine_Id { get; set; }
        [StringLength(50)]
        public string Doze { get; set; }
        [StringLength(int.MaxValue)]
        public string Continuation { get; set; }

    }
}
