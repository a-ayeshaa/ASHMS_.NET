using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.AdminDTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public float Revenue { get; set; }
        public string Transaction_type { get; set; }
        public DateTime Date { get; set; }
    }
}
