﻿using System;
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
        [StringLength(50)]

        public string Reference { get; set; }
        [Required]

        public float Total { get; set; }
        [Required]
        [StringLength(50)]

        public string Status { get; set; }
        [Required]

        public DateTime Date { get; set; }
        [Required]

        public string Report_Delivered { get; set; }

        public virtual Patient Patient { get; set; }    

        public virtual List<TestCart> Carts { get; set; }
        public Test_Transaction()
        {
            Carts = new List<TestCart>();
        }
    }
}