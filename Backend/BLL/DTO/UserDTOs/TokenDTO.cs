using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.UserDTOs
{
    public class TokenDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string token { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public DateTime? expiredAt { get; set; }
        [Required]
        public int User_Id { get; set; }
    }
}
