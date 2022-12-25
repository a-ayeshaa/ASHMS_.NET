using AutoMapper;
using BLL.DTO.AdminDTOs;
using BLL.DTO.DoctorDTOS;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.DoctorServices
{
    public class PrescriptionPresMedicineServices
    {
        public static List<Med_MedPresDTO> medicinePrescriptions(int pres_id)
        {
            var data = DataAccessFactory.MedicinePrescriptionDataAccess().Get();
            var p = (from i in data
                     where i.Prescription_Id==pres_id 
                     select i).ToList();
            var config = new MapperConfiguration(c =>
            {
                //c.CreateMap<Medicine, Med_MedPresDTO>();
                c.CreateMap<MedicinePrescription, Med_MedPresDTO>();
                c.CreateMap<Medicine, MedicineDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<Med_MedPresDTO>>(p);
        }
    }
}
