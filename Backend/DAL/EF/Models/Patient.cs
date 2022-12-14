using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.EF.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]

        public DateTime RegisteredAt { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(3)]
        public string BloodGroup { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual List<TestCart> TestCarts { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
        public virtual List<TestTransaction> TestTransactions { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
        public Patient()
        {
            TestCarts = new List<TestCart>();
            Appointments = new List<Appointment>();
            Transactions = new List<Transaction>();
            TestTransactions = new List<TestTransaction>();
        }
    }
}
