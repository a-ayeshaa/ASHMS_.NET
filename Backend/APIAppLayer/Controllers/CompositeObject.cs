using BLL.DTO.DoctorDTOS;
using BLL.DTO.PatientDTOs;
using BLL.DTO.UserDTOs;

namespace APIAppLayer.Controllers
{
    public class CompositeObject
    {
        public UserDTO User { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }

    }
}