using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PatientDTOs
{
    public class PatientUserDTO:UserDTOs.UserDTO
    {
        public virtual PatientDTO PatientDTO { get; set; }
        public PatientUserDTO()
        {
            PatientDTO = new PatientDTO();
        }
    }
}
