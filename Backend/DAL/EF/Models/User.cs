using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
        public virtual List<Token> Tokens { get; set; }
        public User()
        {
            Patients = new List<Patient>();
            Doctors = new List<Doctor>();
            Tokens = new List<Token>();
        }
    }
}
