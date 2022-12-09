using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.AdminDTOs
{
    public class TestDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
