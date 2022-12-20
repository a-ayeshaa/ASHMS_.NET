using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string token { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? expiredAt { get; set; }
        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }

        public User User { get; set; }

    }
}
